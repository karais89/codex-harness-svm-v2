using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace PromptsLab
{
    [InitializeOnLoad]
    public static class SvmConsoleLogBridge
    {
        private const int Port = 17651;
        private static readonly object Sync = new object();
        private static readonly Queue<ConsoleReadRequest> PendingConsoleReads = new Queue<ConsoleReadRequest>();
        private static HttpListener listener;
        private static Thread listenerThread;
        private static bool running;

        static SvmConsoleLogBridge()
        {
            EditorApplication.update -= ProcessPendingConsoleReads;
            EditorApplication.update += ProcessPendingConsoleReads;
            Start();
        }

        [MenuItem("Tools/Prompts Lab Console Bridge/Start")]
        public static void Start()
        {
            lock (Sync)
            {
                if (running)
                {
                    return;
                }

                listener = new HttpListener();
                listener.Prefixes.Add($"http://127.0.0.1:{Port}/");
                listener.Start();
                running = true;

                listenerThread = new Thread(ListenLoop)
                {
                    IsBackground = true,
                    Name = "SVM Console Log Bridge",
                };
                listenerThread.Start();

                Debug.Log($"SVM Console Log Bridge listening on http://127.0.0.1:{Port}/");
            }
        }

        [MenuItem("Tools/Prompts Lab Console Bridge/Stop")]
        public static void Stop()
        {
            lock (Sync)
            {
                running = false;
                listener?.Close();
                listener = null;
            }
        }

        [MenuItem("Tools/Prompts Lab Console Bridge/Emit Test Logs")]
        public static void EmitTestLogs()
        {
            Debug.Log("SVM bridge test log");
            Debug.LogWarning("SVM bridge test warning");
            Debug.LogError("SVM bridge test error");
        }

        private static void ListenLoop()
        {
            while (running && listener != null)
            {
                try
                {
                    var context = listener.GetContext();
                    Handle(context);
                }
                catch (HttpListenerException)
                {
                    return;
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    Debug.LogError($"SVM Console Log Bridge error: {ex.Message}");
                }
            }
        }

        private static void Handle(HttpListenerContext context)
        {
            if (context.Request.Url == null)
            {
                WriteJson(context, 400, "{\"error\":\"missing url\"}");
                return;
            }

            if (context.Request.Url.AbsolutePath == "/health")
            {
                WriteJson(context, 200, "{\"ok\":true}");
                return;
            }

            if (context.Request.Url.AbsolutePath == "/debug")
            {
                WriteJson(context, 200, DebugReflectionJson());
                return;
            }

            if (context.Request.Url.AbsolutePath != "/console")
            {
                WriteJson(context, 404, "{\"error\":\"not found\"}");
                return;
            }

            var level = context.Request.QueryString["level"] ?? "error";
            var countText = context.Request.QueryString["count"] ?? "20";
            if (!int.TryParse(countText, out var count))
            {
                count = 20;
            }

            var request = new ConsoleReadRequest
            {
                Level = level,
                Count = Math.Max(1, Math.Min(count, 100)),
            };

            lock (PendingConsoleReads)
            {
                PendingConsoleReads.Enqueue(request);
            }

            if (!request.Done.Wait(TimeSpan.FromSeconds(5)))
            {
                WriteJson(context, 504, "{\"error\":\"timed out waiting for Unity main thread\"}");
                return;
            }

            WriteJson(context, 200, request.Json);
        }

        private static void ProcessPendingConsoleReads()
        {
            while (true)
            {
                ConsoleReadRequest request;
                lock (PendingConsoleReads)
                {
                    if (PendingConsoleReads.Count == 0)
                    {
                        return;
                    }

                    request = PendingConsoleReads.Dequeue();
                }

                try
                {
                    var entries = ReadConsoleEntries(request.Level, request.Count);
                    request.Json = ToJson(request.Level, entries);
                }
                catch (Exception ex)
                {
                    request.Json = "{\"error\":\"" + Escape(ex.Message) + "\"}";
                }
                finally
                {
                    request.Done.Set();
                }
            }
        }

        private static List<string> ReadConsoleEntries(string level, int count)
        {
            var entries = new List<string>();
            var logEntriesType = Type.GetType("UnityEditor.LogEntries,UnityEditor");
            var logEntryType = Type.GetType("UnityEditor.LogEntry,UnityEditor");
            if (logEntriesType == null || logEntryType == null)
            {
                entries.Add("Unable to reflect UnityEditor.LogEntries.");
                return entries;
            }

            var getCount = logEntriesType.GetMethod("GetCount", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var start = logEntriesType.GetMethod("StartGettingEntries", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var end = logEntriesType.GetMethod("EndGettingEntries", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var getEntry = logEntriesType.GetMethod("GetEntryInternal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var messageField = logEntryType.GetField("message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (getCount == null || getEntry == null || messageField == null)
            {
                entries.Add("Unable to reflect required Unity Console methods.");
                return entries;
            }

            var total = (int)getCount.Invoke(null, null);
            start?.Invoke(null, null);
            try
            {
                var entry = Activator.CreateInstance(logEntryType);
                for (var i = Math.Max(0, total - 500); i < total; i++)
                {
                    getEntry.Invoke(null, new[] { i, entry });
                    var message = messageField.GetValue(entry) as string;
                    if (string.IsNullOrWhiteSpace(message))
                    {
                        continue;
                    }

                    if (MatchesLevel(message, level))
                    {
                        entries.Add(message.Trim());
                    }
                }
            }
            finally
            {
                end?.Invoke(null, null);
            }

            if (entries.Count <= count)
            {
                return entries;
            }

            return entries.GetRange(entries.Count - count, count);
        }

        private static string DebugReflectionJson()
        {
            var logEntriesType = Type.GetType("UnityEditor.LogEntries,UnityEditor");
            var logEntryType = Type.GetType("UnityEditor.LogEntry,UnityEditor");
            var builder = new StringBuilder();
            builder.Append("{\"logEntriesType\":");
            AppendNullableString(builder, logEntriesType?.FullName);
            builder.Append(",\"logEntryType\":");
            AppendNullableString(builder, logEntryType?.FullName);
            builder.Append(",\"logEntriesMethods\":[");
            if (logEntriesType != null)
            {
                var methods = logEntriesType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                for (var i = 0; i < methods.Length; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(",");
                    }

                    builder.Append("\"");
                    builder.Append(Escape(methods[i].Name));
                    builder.Append("\"");
                }
            }

            builder.Append("],\"logEntryFields\":[");
            if (logEntryType != null)
            {
                var fields = logEntryType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                for (var i = 0; i < fields.Length; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(",");
                    }

                    builder.Append("\"");
                    builder.Append(Escape(fields[i].Name));
                    builder.Append("\"");
                }
            }

            builder.Append("]}");
            return builder.ToString();
        }

        private static void AppendNullableString(StringBuilder builder, string value)
        {
            if (value == null)
            {
                builder.Append("null");
                return;
            }

            builder.Append("\"");
            builder.Append(Escape(value));
            builder.Append("\"");
        }

        private static bool MatchesLevel(string message, string level)
        {
            var lower = message.ToLowerInvariant();
            switch (level)
            {
                case "log":
                    return true;
                case "warning":
                    return lower.Contains("warning") || lower.Contains("warn");
                case "error":
                default:
                    return lower.Contains("error") || lower.Contains("exception") || lower.Contains("failed");
            }
        }

        private static string ToJson(string level, List<string> entries)
        {
            var builder = new StringBuilder();
            builder.Append("{\"source\":\"UnityEditor.LogEntries\",\"level\":\"");
            builder.Append(Escape(level));
            builder.Append("\",\"count\":");
            builder.Append(entries.Count);
            builder.Append(",\"logs\":[");
            for (var i = 0; i < entries.Count; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                }

                builder.Append("\"");
                builder.Append(Escape(entries[i]));
                builder.Append("\"");
            }

            builder.Append("]}");
            return builder.ToString();
        }

        private static string Escape(string value)
        {
            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r");
        }

        private static void WriteJson(HttpListenerContext context, int status, string json)
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentLength64 = bytes.Length;
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            context.Response.OutputStream.Close();
        }

        private sealed class ConsoleReadRequest
        {
            public string Level;
            public int Count;
            public string Json;
            public ManualResetEventSlim Done = new ManualResetEventSlim(false);
        }
    }
}

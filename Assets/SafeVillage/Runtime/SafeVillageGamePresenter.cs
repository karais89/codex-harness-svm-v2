using System.Collections.Generic;
using SafeVillage.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SafeVillage.Runtime
{
    public sealed class SafeVillageGamePresenter : MonoBehaviour
    {
        private VillageGame game;
        private readonly List<string> reportLog = new List<string>();

        private int forage = 1;
        private int guard = 1;
        private int repair = 1;
        private string validationMessage = string.Empty;

        private TextMeshProUGUI stateText;
        private TextMeshProUGUI forageCountText;
        private TextMeshProUGUI guardCountText;
        private TextMeshProUGUI repairCountText;
        private TextMeshProUGUI validationText;
        private TextMeshProUGUI logText;
        private Button resolveButton;

        private void Awake()
        {
            game = new VillageGame();
            EnsureUi();
            Refresh();
        }

        private void EnsureUi()
        {
            if (stateText != null)
            {
                return;
            }

            var canvasObject = new GameObject("SafeVillageCanvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            canvasObject.transform.SetParent(transform, false);

            var canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 0;

            var scaler = canvasObject.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1280f, 720f);
            scaler.matchWidthOrHeight = 0.5f;

            CreateBackground(canvasObject.transform);

            stateText = CreateText(
                "StateText",
                canvasObject.transform,
                new Vector2(48f, -40f),
                new Vector2(420f, 220f),
                28f,
                TextAlignmentOptions.TopLeft);

            var assignmentTitle = CreateText(
                "AssignmentTitle",
                canvasObject.transform,
                new Vector2(520f, -42f),
                new Vector2(360f, 40f),
                24f,
                TextAlignmentOptions.TopLeft);
            assignmentTitle.text = "Assignment";

            CreateAssignmentRow(canvasObject.transform, "Forage", new Vector2(520f, -96f), VillageAction.Forage, out forageCountText);
            CreateAssignmentRow(canvasObject.transform, "Guard", new Vector2(520f, -150f), VillageAction.Guard, out guardCountText);
            CreateAssignmentRow(canvasObject.transform, "Repair", new Vector2(520f, -204f), VillageAction.Repair, out repairCountText);

            validationText = CreateText(
                "ValidationText",
                canvasObject.transform,
                new Vector2(520f, -268f),
                new Vector2(560f, 38f),
                20f,
                TextAlignmentOptions.MidlineLeft);

            resolveButton = CreateButton(
                "ResolveButton",
                "Resolve Day",
                canvasObject.transform,
                new Vector2(520f, -322f),
                new Vector2(168f, 44f),
                ResolveCurrentDay);

            CreateButton(
                "RestartButton",
                "Restart",
                canvasObject.transform,
                new Vector2(704f, -322f),
                new Vector2(132f, 44f),
                RestartGame);

            logText = CreateText(
                "DayReportLog",
                canvasObject.transform,
                new Vector2(48f, -332f),
                new Vector2(1120f, 320f),
                21f,
                TextAlignmentOptions.TopLeft);
        }

        private void Refresh()
        {
            var state = game.State;
            stateText.text =
                "Safe Village Micro\n" +
                $"Day: {state.Day}\n" +
                $"Food: {state.Food}\n" +
                $"Wall: {state.Wall}/{state.MaxWall}\n" +
                $"Villagers: {state.Villagers}\n" +
                $"Outcome: {state.Outcome}";

            forageCountText.text = forage.ToString();
            guardCountText.text = guard.ToString();
            repairCountText.text = repair.ToString();

            validationText.text = CurrentValidationText();
            validationText.color = game.CanResolve(CurrentAssignment, out _) ?
                new Color32(178, 220, 186, 255) :
                new Color32(244, 195, 124, 255);

            resolveButton.interactable = !state.IsTerminal;
            logText.text = reportLog.Count == 0 ? "Day report log" : string.Join("\n", reportLog);
        }

        private void ResolveCurrentDay()
        {
            var assignment = CurrentAssignment;
            if (!game.CanResolve(assignment, out var reason))
            {
                validationMessage = reason;
                Refresh();
                return;
            }

            var report = game.ResolveDay(assignment);
            reportLog.Add(report.Summary);
            validationMessage = string.Empty;
            Refresh();
        }

        private void RestartGame()
        {
            game.Restart();
            reportLog.Clear();
            forage = 1;
            guard = 1;
            repair = 1;
            validationMessage = string.Empty;
            Refresh();
        }

        private void ChangeAssignment(VillageAction action, int delta)
        {
            switch (action)
            {
                case VillageAction.Forage:
                    forage = Mathf.Max(0, forage + delta);
                    break;
                case VillageAction.Guard:
                    guard = Mathf.Max(0, guard + delta);
                    break;
                case VillageAction.Repair:
                    repair = Mathf.Max(0, repair + delta);
                    break;
            }

            validationMessage = string.Empty;
            Refresh();
        }

        private VillageAssignment CurrentAssignment => new VillageAssignment(forage, guard, repair);

        private string CurrentValidationText()
        {
            if (!string.IsNullOrEmpty(validationMessage))
            {
                return validationMessage;
            }

            if (!game.CanResolve(CurrentAssignment, out var reason))
            {
                return reason;
            }

            return "Ready";
        }

        private static void CreateBackground(Transform parent)
        {
            var backgroundObject = new GameObject("Background", typeof(RectTransform), typeof(Image));
            backgroundObject.transform.SetParent(parent, false);

            var rectTransform = backgroundObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            var image = backgroundObject.GetComponent<Image>();
            image.color = new Color32(25, 32, 33, 255);
            backgroundObject.transform.SetAsFirstSibling();
        }

        private void CreateAssignmentRow(
            Transform parent,
            string label,
            Vector2 position,
            VillageAction action,
            out TextMeshProUGUI countText)
        {
            var labelText = CreateText(
                label + "Label",
                parent,
                position,
                new Vector2(130f, 38f),
                21f,
                TextAlignmentOptions.MidlineLeft);
            labelText.text = label;

            countText = CreateText(
                label + "Count",
                parent,
                position + new Vector2(150f, 0f),
                new Vector2(48f, 38f),
                24f,
                TextAlignmentOptions.Center);

            CreateButton(
                label + "MinusButton",
                "-",
                parent,
                position + new Vector2(218f, 0f),
                new Vector2(44f, 38f),
                () => ChangeAssignment(action, -1));

            CreateButton(
                label + "PlusButton",
                "+",
                parent,
                position + new Vector2(272f, 0f),
                new Vector2(44f, 38f),
                () => ChangeAssignment(action, 1));
        }

        private static TextMeshProUGUI CreateText(
            string name,
            Transform parent,
            Vector2 position,
            Vector2 size,
            float fontSize,
            TextAlignmentOptions alignment)
        {
            var textObject = new GameObject(name, typeof(RectTransform), typeof(TextMeshProUGUI));
            textObject.transform.SetParent(parent, false);

            SetTopLeft(textObject.GetComponent<RectTransform>(), position, size);

            var text = textObject.GetComponent<TextMeshProUGUI>();
            text.fontSize = fontSize;
            text.lineSpacing = 10f;
            text.alignment = alignment;
            text.enableWordWrapping = true;
            text.color = new Color32(232, 238, 235, 255);
            return text;
        }

        private static Button CreateButton(
            string name,
            string label,
            Transform parent,
            Vector2 position,
            Vector2 size,
            UnityAction onClick)
        {
            var buttonObject = new GameObject(name, typeof(RectTransform), typeof(Image), typeof(Button));
            buttonObject.transform.SetParent(parent, false);
            SetTopLeft(buttonObject.GetComponent<RectTransform>(), position, size);

            var image = buttonObject.GetComponent<Image>();
            var button = buttonObject.GetComponent<Button>();
            button.targetGraphic = image;

            var colors = button.colors;
            colors.normalColor = new Color32(214, 226, 216, 255);
            colors.highlightedColor = new Color32(236, 244, 237, 255);
            colors.pressedColor = new Color32(174, 196, 178, 255);
            colors.selectedColor = colors.normalColor;
            colors.disabledColor = new Color32(95, 104, 100, 160);
            button.colors = colors;
            button.onClick.AddListener(onClick);

            var labelText = CreateText(
                name + "Label",
                buttonObject.transform,
                Vector2.zero,
                size,
                20f,
                TextAlignmentOptions.Center);
            var labelRect = labelText.GetComponent<RectTransform>();
            labelRect.anchorMin = Vector2.zero;
            labelRect.anchorMax = Vector2.one;
            labelRect.offsetMin = Vector2.zero;
            labelRect.offsetMax = Vector2.zero;
            labelText.text = label;
            labelText.color = new Color32(18, 24, 22, 255);

            return button;
        }

        private static void SetTopLeft(RectTransform rectTransform, Vector2 position, Vector2 size)
        {
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.anchoredPosition = position;
            rectTransform.sizeDelta = size;
        }
    }
}

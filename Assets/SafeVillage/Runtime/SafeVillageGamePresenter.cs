using SafeVillage.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SafeVillage.Runtime
{
    public sealed class SafeVillageGamePresenter : MonoBehaviour
    {
        private VillageGame game;
        private TextMeshProUGUI stateText;

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

            var textObject = new GameObject("InitialStateText", typeof(RectTransform), typeof(TextMeshProUGUI));
            textObject.transform.SetParent(canvasObject.transform, false);

            var rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(0f, 1f);
            rectTransform.anchoredPosition = new Vector2(48f, -48f);
            rectTransform.sizeDelta = new Vector2(520f, 260f);

            stateText = textObject.GetComponent<TextMeshProUGUI>();
            stateText.fontSize = 32f;
            stateText.lineSpacing = 16f;
            stateText.alignment = TextAlignmentOptions.TopLeft;
            stateText.color = new Color32(232, 238, 235, 255);
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
        }
    }
}

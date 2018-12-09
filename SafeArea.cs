using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour {

    private RectTransform safeAreaRect;
    private Canvas canvas;
    private Rect lastSafeArea;

    void Start() {
        safeAreaRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        OnRectTransformDimensionsChange();
    }

    private void OnRectTransformDimensionsChange() {

        if (Screen.safeArea != lastSafeArea && canvas != null) {
            lastSafeArea = Screen.safeArea;
            UpdateSizeToSafeArea();
        }
    }

    private void UpdateSizeToSafeArea() {

        var safeArea = Screen.safeArea;
        var inverseSize = new Vector2(1f, 1f) / canvas.pixelRect.size; 
        var newAnchorMin = Vector2.Scale(safeArea.position, inverseSize);
        var newAnchorMax = Vector2.Scale(safeArea.position + safeArea.size, inverseSize);

        safeAreaRect.anchorMin = newAnchorMin;
        safeAreaRect.anchorMax = newAnchorMax;

        safeAreaRect.offsetMin = Vector2.zero;
        safeAreaRect.offsetMax = Vector2.zero;
    }    
}
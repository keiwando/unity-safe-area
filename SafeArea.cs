using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour {

    private RectTransform safeAreaRect;
    private Canvas canvas;
    private Rect lastSafeArea;

    void Start() {
        safeAreaRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        UpdateSizeToSafeArea();
    }

    private void OnRectTransformDimensionsChange() {

        if (Screen.safeArea != lastSafeArea) {
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
    }    
}
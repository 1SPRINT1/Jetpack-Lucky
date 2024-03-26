using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private void Awake()
    {
        RefreshRectTransform();
    }

    public void RefreshRectTransform()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect safeArea = Screen.safeArea;
        safeArea.y = 0;

        Vector2 minAnchor = safeArea.position;
        Vector2 maxAnchor = minAnchor + safeArea.size;
        Vector2 difference = new Vector2(Screen.width - safeArea.width, Screen.height - safeArea.height);

        if (Screen.safeArea.height / Screen.height < 0.92)
        {
            difference /= 2;
        }

        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                minAnchor = Vector2.zero;
                maxAnchor = new Vector2(Screen.width, Screen.height) - new Vector2(0, difference.y);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                minAnchor = new Vector2(0, difference.y);
                maxAnchor = new Vector2(Screen.width, Screen.height);
                break;
            case ScreenOrientation.LandscapeLeft:
                minAnchor = new Vector2(difference.x/2, 0);
                maxAnchor = new Vector2(Screen.width, Screen.height);
                break;
            case ScreenOrientation.LandscapeRight:
                minAnchor = Vector2.zero;
                maxAnchor = new Vector2(Screen.width, Screen.height) - new Vector2(difference.x/2, 0);
                break;
        }

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
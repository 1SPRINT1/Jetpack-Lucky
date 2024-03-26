using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoRotate : MonoBehaviour
{
    [Header("Autorotate To:")]
    [SerializeField] bool landscapeLeft = true;
    [SerializeField] bool landscapeRight = true;
    [SerializeField] bool portrait = true;
    [SerializeField] bool portraitUpsideDown = true;

    [SerializeField] Image rotateDeviceImage;

    void Start()
    {
        Screen.autorotateToLandscapeLeft = landscapeLeft;
        Screen.autorotateToLandscapeRight = landscapeRight;
        Screen.autorotateToPortrait = portrait;
        Screen.autorotateToPortraitUpsideDown = portraitUpsideDown;

        bool correctOrientation = CheckCorrectOrientation();

        if (rotateDeviceImage != null)
        {
            if (!correctOrientation)
                StartCoroutine(ChangeOrientationCoroutine());

            rotateDeviceImage.gameObject.SetActive(!correctOrientation);
        }
    }

    public void ChangeOrientationPossibility(bool top, bool left, bool right, bool bottom)
    {
        Screen.autorotateToPortrait = top;
        Screen.autorotateToLandscapeLeft = left;
        Screen.autorotateToLandscapeRight = right;
        Screen.autorotateToPortraitUpsideDown = bottom;
    }

    private bool CheckCorrectOrientation()
    {
        bool orientationIsCorrect = false;

        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
            case ScreenOrientation.PortraitUpsideDown:
                orientationIsCorrect = portrait || portraitUpsideDown;
                break;
            case ScreenOrientation.LandscapeLeft:
            case ScreenOrientation.LandscapeRight:
                orientationIsCorrect = landscapeLeft || landscapeRight;
                break;
            case ScreenOrientation.AutoRotation:
                orientationIsCorrect = true;
                break;
        }

        return orientationIsCorrect;
    }

    IEnumerator ChangeOrientationCoroutine()
    {
        while (!CheckCorrectOrientation())
        {
            yield return null;
        }

        rotateDeviceImage.gameObject.SetActive(false);
    }
}
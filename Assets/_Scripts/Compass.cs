using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compass : MonoBehaviour
{
    public RawImage compassImage;
    public Transform cameraTransform;

    void Update()
    {
        compassImage.uvRect = new Rect(cameraTransform.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}

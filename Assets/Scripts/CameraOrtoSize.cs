using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrtoSize : MonoBehaviour {

    public float pixelsPerUnit = 64f;

    void LateUpdate() {
        float height = Screen.height;
        float ortoSize = height / pixelsPerUnit / 2f;
        Camera.main.orthographicSize = ortoSize;
    }
}

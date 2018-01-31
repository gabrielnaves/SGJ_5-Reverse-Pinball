using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    public bool clockwise;
    public float rotateAngle = 45f;
    public float rotateTime = 1f;
    public bool rotating;

    float elapsedTime;
    Rigidbody2D rigidbody2d;

    float startAngle;
    float endAngle;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Rotate() {
        rotating = true;
        startAngle = 0f;
        if (!clockwise) endAngle = startAngle + rotateAngle;
        else endAngle = startAngle - rotateAngle;
        elapsedTime = 0f;
    }

    void FixedUpdate() {
        if (rotating) {
            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime > rotateTime)
                StartCoroutine(ReturnToStartRotation());
            else
                rigidbody2d.MoveRotation(Mathf.Lerp(startAngle, endAngle, elapsedTime / rotateTime));
        }
    }

    IEnumerator ReturnToStartRotation() {
        rotating = false;
        float elapsedTime = 0f;
        while (elapsedTime < rotateTime) {
            rigidbody2d.MoveRotation(Mathf.Lerp(endAngle, startAngle, elapsedTime / rotateTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rigidbody2d.MoveRotation(startAngle);
        yield break;
    }
}

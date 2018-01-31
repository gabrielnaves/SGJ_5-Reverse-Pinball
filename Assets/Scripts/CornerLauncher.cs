using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerLauncher : MonoBehaviour {

    public bool launching;
    public bool launched;
    public float distance;
    public float animationTime = 3f;
    public float launchForce = 1f;

    void Awake() {
        GetComponent<SpringJoint2D>().connectedAnchor = transform.position;
        GetComponent<SpringJoint2D>().distance = 0f;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (!launching)
            StartCoroutine(Launch());
        else if (launched)
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
    }

    IEnumerator Launch() {
        launching = true;
        GetComponent<SpringJoint2D>().enabled = false;
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;
        Vector2 finalPosition = startPosition;
        finalPosition.y -= distance;
        while (elapsedTime < animationTime) {
            elapsedTime += Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(startPosition, finalPosition, elapsedTime / animationTime));
            yield return null;
        }
        GetComponent<SpringJoint2D>().enabled = true;
        GetComponent<SpringJoint2D>().distance = 0;
        launched = true;
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLauncher : MonoBehaviour {

    static public StartLauncher instance;
    public bool launched;
    public float distance;
    public float animationTime = 3f;
    public float launchForce = 1f;

    void Awake() {
        instance = this;
    }

    void Update() {
        if (!launched && RequestedLaunch())
            StartCoroutine(Launch());
    }

    bool RequestedLaunch() {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
    }

    IEnumerator Launch() {
        launched = true;
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
        yield break;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (launched)
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
    }
}

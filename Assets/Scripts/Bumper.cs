using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public float forceOnCollision = 1f;

    void OnCollisionEnter2D(Collision2D other) {
        Vector2 force = other.transform.position - transform.position;
        force = force.normalized * forceOnCollision;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}

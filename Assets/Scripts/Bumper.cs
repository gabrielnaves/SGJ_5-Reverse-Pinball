using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public float forceOnCollision = 10f;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        animator.SetTrigger("hit");
        Vector2 force = other.transform.position - transform.position;
        force = force.normalized * forceOnCollision;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        Score.instance.score += 10;
    }
}

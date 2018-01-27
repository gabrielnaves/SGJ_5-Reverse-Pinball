using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour {

    public float forceOnCollision = 10f;
    public string animatorTrigger;

    Animator animator;

    void Awake() {
        animator = transform.parent.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        animator.SetTrigger(animatorTrigger);
        Vector2 force = (other.transform.position - transform.position).normalized * forceOnCollision;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}

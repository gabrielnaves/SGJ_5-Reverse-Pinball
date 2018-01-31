using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float inputForce = 1f;

    Rigidbody2D rigidbody2d;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") / 2f);
        input *= inputForce;
        rigidbody2d.AddForce(input);
    }
}

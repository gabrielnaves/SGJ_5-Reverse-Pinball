using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperTrigger : MonoBehaviour {

    public Flipper flipper;

    void OnTriggerEnter2D(Collider2D other) {
        if (!flipper.rotating)
            flipper.Rotate();
    }
}

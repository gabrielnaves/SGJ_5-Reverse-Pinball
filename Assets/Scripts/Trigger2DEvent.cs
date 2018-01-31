using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger2DEvent : MonoBehaviour {

    public GameObject target;
    public UnityEvent onTriggerEnter;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == target)
            onTriggerEnter.Invoke();
    }
}

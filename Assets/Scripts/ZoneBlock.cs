using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBlock : MonoBehaviour {

    public bool isOpen = true;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Open() {
        if (!isOpen) {
            animator.SetTrigger("open");
            isOpen = true;
        }
    }

    public void Close() {
        if (isOpen) {
            animator.SetTrigger("close");
            isOpen = false;
        }
    }
}

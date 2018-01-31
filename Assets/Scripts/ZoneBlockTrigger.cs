using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBlockTrigger : MonoBehaviour {

    public int blockingNumber;
    public ZoneBlock block;

    void OnTriggerEnter2D(Collider2D other) {
        blockingNumber--;
        if (blockingNumber == 0) {
            block.Close();
        }
    }
}

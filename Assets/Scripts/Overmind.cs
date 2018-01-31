using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overmind : MonoBehaviour {

    public GameObject ball;
    public ZoneBlock[] blocks;
    public ZoneBlockTrigger[] triggers;
    public StartLauncher startLauncher;
    public CornerLauncher[] cornerLaunchers;

    Vector3 startBallPos;

    void Awake() {
        startBallPos = ball.transform.position;
    }

    public void Reset() {
        ResetBall();
        ResetBlocks();
        ResetLaunchers();
    }

    void ResetBall() {
        ball.transform.position = startBallPos;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void ResetBlocks() {
        foreach (ZoneBlock block in blocks)
            block.Open();
        foreach (ZoneBlockTrigger trigger in triggers)
            trigger.Reset();
    }

    void ResetLaunchers() {
        startLauncher.launched = false;
        foreach (CornerLauncher launcher in cornerLaunchers)
            launcher.launched = launcher.launching = false;
    }
}

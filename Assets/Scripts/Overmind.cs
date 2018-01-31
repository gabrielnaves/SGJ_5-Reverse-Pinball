using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overmind : MonoBehaviour {

    static public Overmind instance { get; private set; }

    public int ballAmount = 3;
    public GameObject ball;
    public ZoneBlock[] blocks;
    public ZoneBlockTrigger[] triggers;
    public StartLauncher startLauncher;
    public CornerLauncher[] cornerLaunchers;

    Vector3 startBallPos;

    void Awake() {
        instance = this;
        startBallPos = ball.transform.position;
    }

    public void Reset() {
        if (startLauncher.launched) {
            UpdateGameCount();
            ResetBall();
            ResetBlocks();
            ResetLaunchers();
        }
    }

    void UpdateGameCount() {
        ballAmount--;
        if (ballAmount <= 0)
            SceneManager.LoadScene("gameover");
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

    void Update() {
        if (Input.GetKeyDown(KeyCode.B))
            SceneManager.LoadScene("menu");
    }
}

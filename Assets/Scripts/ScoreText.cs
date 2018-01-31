using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = "Score: " + Score.instance.score;
        if (Score.instance.score < 150)
            text.color = Color.green;
        else if (Score.instance.score < 300)
            text.color = Color.yellow;
        else
            text.color = Color.red;
    }
}

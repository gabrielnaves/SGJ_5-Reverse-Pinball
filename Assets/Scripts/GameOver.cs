using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text scoreText;

    void Start() {
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "Player score: " + score;
        if (score < 150)
            scoreText.color = Color.green;
        else if (score < 300)
            scoreText.color = Color.yellow;
        else
            scoreText.color = Color.red;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("menu");
    }
}

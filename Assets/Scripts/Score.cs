using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    static public Score instance { get; private set; }

    public int score = 0;

    void Awake() {
        instance = this;
    }

    void OnDestroy() {
        PlayerPrefs.SetInt("score", score);
    }
}

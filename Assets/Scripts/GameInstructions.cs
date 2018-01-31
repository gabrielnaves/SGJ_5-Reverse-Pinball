using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInstructions : MonoBehaviour {

    Text instructionText;
    string text;

    void Awake() {
        instructionText = GetComponent<Text>();
        text = instructionText.text;
    }

    void Update() {
        if (StartLauncher.instance.launched)
            instructionText.text = "";
        else
            instructionText.text = text;
    }
}

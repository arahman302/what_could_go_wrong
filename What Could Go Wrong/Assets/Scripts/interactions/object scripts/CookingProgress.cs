using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CookingProgress : MonoBehaviour {
    private float levelTimeLeft = 90f;
    private bool timeIsRunning = true;
    [SerializeField] private TMP_Text timerText;
    
    void Start() {
        timeIsRunning = true;
    }

    void Update() {
        while (timeIsRunning) {
            if (levelTimeLeft <= 0) {
                timeIsRunning = false;
            }
            levelTimeLeft += Time.deltaTime;
            DisplayProgress(levelTimeLeft);
        }
    }

    void DisplayProgress(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
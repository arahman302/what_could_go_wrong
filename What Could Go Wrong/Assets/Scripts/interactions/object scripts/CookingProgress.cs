using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CookingProgress : MonoBehaviour {
    [SerializeField] private float timePassed = 0;
    [SerializeField] private float timeRemaining = 90f;
    private bool timeIsRunning = true;
    [SerializeField] private TMP_Text timerText;
    
    void Start() {
        timeIsRunning = true;
        Time.timeScale = 1.0f;
    }

    void Update() {
        //inside while loop, code seems to end immedietly
        if (timeRemaining >= 0) {
            //outside of while loop, code runs at expected pace
            //timePassed += Time.deltaTime;
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            if (seconds >= 0) {
                timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);
            }
            
        }
        // if (timePassed > 90) {
        //     timeIsRunning = false;
        // }
    }
}
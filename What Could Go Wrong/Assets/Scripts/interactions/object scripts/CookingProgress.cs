using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CookingProgress : MonoBehaviour {
    [SerializeField] private float timePassed = 0;
    [SerializeField] private float timeRemaining = 90f;
    private bool timeIsRunning = true;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject pot;
    [SerializeField] private GameObject fryingPan;
    [SerializeField] private GameObject cuttingBoard;
    [SerializeField] private GameObject toaster;
    [SerializeField] public static Food[] ingredients;
    void Start() {
        timeIsRunning = true;
        Time.timeScale = 1.0f;

        //make foods
        Food steak = new Food("steak", false, fryingPan);
        Food fish = new Food("fish", true, pot);
        Food bread = new Food("bread", false, toaster);
        Food garlic = new Food("garlic", true, pot);
        Food pepper = new Food("pepper", true, fryingPan);
        Food lemon = new Food("lemon", true, pot);

        ingredients = new [] {steak, fish, bread, garlic, pepper, lemon};

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
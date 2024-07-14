using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    private string[] ingredients;
    [SerializeField] private bool atSink;
    [SerializeField] private bool atStove;
    [SerializeField] private bool hasWater;
    [SerializeField] private float waterTime = 3f;
    [SerializeField] private float cookTime = 15f;
    [SerializeField] private List<Food> currentItems = new List<Food>();
    void Start() {
        ingredients = new [] {"fish", "garlic", "lemon"};
        hasWater = false;
        atSink = false;
    }
    void Update() {
        if (!hasWater && atSink && Input.GetKey(KeyCode.E)) {
            waterTime-= Time.deltaTime;
            Debug.Log("Getting water..." + Mathf.FloorToInt(waterTime));
            if (waterTime <= 0) {
                Debug.Log("got water");
                hasWater = true;
            }
        } else if (!hasWater && (!atSink || Input.GetKeyUp(KeyCode.E))){
            Debug.Log("stopped water");
            waterTime = 3f;
        } else if (hasWater && atStove && currentItems.Count >= 1) {
            Debug.Log("cooking...");
            cookTime -= Time.deltaTime;
        } else if (hasWater && currentItems.Count >=1 && cookTime != 15f) {
            if (cookTime < 0) {
                Debug.Log("undercooked!");
            } else if (cookTime > 0) {
                Debug.Log("overcooked!");
            } else {
                Debug.Log("just right!");
            }
        }
    }
    // void OnCollisionEnter(Collision col) {
    //     if (col.gameObject.name.Equals("fish")) {
    //         currentItems.Add(CookingProgress.ingredients.GetValue(1));
    //     } else if (col.gameObject.name.Equals("fish")) {
    //         currentItems.Add(CookingProgress.ingredients.GetValue(1));
    //     }
    // }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("sink")) {
            Debug.Log("at sink");
            atSink = true;
        } else if (col.gameObject.name.Equals("stove")) {
            Debug.Log("at stove");
            atStove = true;
        }
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.name.Equals("sink")) {
            Debug.Log("leaving sink");
            atSink = false;
        } else if (col.gameObject.name.Equals("stove")) {
            Debug.Log("at stove");
            atStove = false;
        }
    }

    void getWater() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    private string[] ingredients;
    [SerializeField] private bool atSink;
    [SerializeField] private bool hasWater;
    [SerializeField] private float waterTime = 3f;
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
        }
    }
    void OnCollisionEnter(Collision col) {
        
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("sink")) {
            Debug.Log("at sink");
            atSink = true;
        }
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.name.Equals("sink")) {
            Debug.Log("leaving sink");
            atSink = false;
        }
    }

    void getWater() {

    }
}

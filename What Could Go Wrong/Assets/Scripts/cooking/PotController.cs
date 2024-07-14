using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    //private string[] ingredients;
    [SerializeField] private bool atSink;
    [SerializeField] private bool atStove;
    [SerializeField] private bool hasWater;
    [SerializeField] private float waterTime = 3f;
    [SerializeField] private float cookTime = 15f;
    //[SerializeField] private List<Food> currentItems = new List<Food>();
    private Food fish;
    private Food garlic;
    private Food lemon;
    private int ingCount = 0;
    public bool isServed;
    void Start() {
        //ingredients = new [] {"fish", "garlic", "lemon"};
        hasWater = false;
        atSink = false;
        isServed = false;
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
            //Debug.Log("stopped water");
            waterTime = 3f;
        } else if (hasWater && atStove && ingCount >= 1) {
            Debug.Log("cooking...");
            cookTime -= Time.deltaTime;
        } else if (cookTime != 15f) {
            evaluate(cookTime);
        }
    }
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name.Equals("fish")) {
            if (fish == null) {
                fish = (Food)CookingProgress.ingredients.GetValue(1);
                if (fish.getChopped()) {
                    ingCount++;
                    col.gameObject.SetActive(false);
                } else {
                    fish = null;
                }
            }
        } else if (col.gameObject.name.Equals("garlic")) {
            if (garlic == null) {
                garlic = (Food)CookingProgress.ingredients.GetValue(3);
                if (garlic.getChopped()) {
                    ingCount++;
                    col.gameObject.SetActive(false);
                } else {
                    garlic = null;
                }
            }
        } else if (col.gameObject.name.Equals("lemon")) {
            if (lemon == null) {
                lemon = (Food)CookingProgress.ingredients.GetValue(5);
                if (lemon.getChopped()) {
                    ingCount++;
                    col.gameObject.SetActive(false);
                } else {
                    lemon = null;
                }
            }
        }
        Debug.Log(ingCount);
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("sink")) {
            Debug.Log("at sink");
            atSink = true;
        } else if (col.gameObject.name.Equals("stove")) {
            Debug.Log("at stove");
            atStove = true;
        } else if (col.gameObject.name.Equals("bowl")) {
            isServed = true;
            serve();
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

    private void evaluate(float time) {
        if (time > 2f) {
            if (fish != null) {
                fish.setStatus(-1);
            } 
            if (garlic != null) {
                garlic.setStatus(-1);
            }
            if (lemon != null) {
                lemon.setStatus(-1);
            }
        } else if (time < 2f) {
            if (fish != null) {
                fish.setStatus(1);
            } 
            if (garlic != null) {
                garlic.setStatus(1);
            }
            if (lemon != null) {
                lemon.setStatus(1);
            }
        } else {
            if (fish != null) {
                fish.setStatus(0);
            } 
            if (garlic != null) {
                garlic.setStatus(0);
            }
            if (lemon != null) {
                lemon.setStatus(0);
            }
        }
    }

    private void serve() {
        if (fish != null) {
                fish.serve();
            } 
            if (garlic != null) {
                garlic.serve();
            }
            if (lemon != null) {
                lemon.serve();
            }
    }
}

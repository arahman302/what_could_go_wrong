using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController : MonoBehaviour
{
    [SerializeField] private bool atStove;
    [SerializeField] private float cookTime = 15f;
    //[SerializeField] private List<Food> currentItems = new List<Food>();
    private Food steak;
    private Food pepper;
    private int ingCount = 0;
    public bool isServed;
    void Start() {
        atStove = false;
        isServed = false;
    }
    void Update() {
        if (atStove && ingCount >= 1) {
            Debug.Log("cooking...");
            cookTime -= Time.deltaTime;
        } else if (!atStove && ingCount >=1 && cookTime != 15f) {
           evaluate(cookTime);
        }
    }
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name.Equals("steak")) {
            if (steak == null) {
                steak = (Food)CookingProgress.ingredients.GetValue(0);
                if (steak.getChopped()) {
                    ingCount++;
                    col.gameObject.SetActive(false);
                } else {
                    steak = null;
                }
            }
        } else if (col.gameObject.name.Equals("pepper")) {
            if (pepper == null) {
                pepper = (Food)CookingProgress.ingredients.GetValue(4);
                if (pepper.getChopped()) {
                    ingCount++;
                    col.gameObject.SetActive(false);
                } else {
                    pepper = null;
                }
            }
        }
        Debug.Log(ingCount);
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("stove")) {
            Debug.Log("at stove");
            atStove = true;
        } else if (col.gameObject.name.Equals("plate")) {
            isServed = true;
            serve();
        }
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.name.Equals("stove")) {
            Debug.Log("at stove");
            atStove = false;
        }
    }

     private void evaluate(float time) {
        if (time > 2f) {
            if (steak != null) {
                steak.setStatus(-1);
            } 
            if (pepper != null) {
                pepper.setStatus(-1);
            }
        } else if (time < 2f) {
            if (steak != null) {
                steak.setStatus(1);
            } 
            if (pepper != null) {
                pepper.setStatus(1);
            }
        } else {
            if (steak != null) {
                steak.setStatus(0);
            } 
            if (pepper != null) {
                pepper.setStatus(0);
            }
        }
    }

    private void serve() {
        if (steak != null) {
                steak.serve();
            } 
            if (pepper != null) {
                pepper.serve();
            }
    }

}

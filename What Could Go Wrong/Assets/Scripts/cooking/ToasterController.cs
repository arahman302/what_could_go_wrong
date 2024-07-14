using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterController : MonoBehaviour
{
    [SerializeField] private float cookTime = 15f;
    //[SerializeField] private List<Food> currentItems = new List<Food>();
    private Food bread;
    private GameObject breadObj;
    private int ingCount = 0;
    public bool isServed;
    private bool cooking;
    [SerializeField] private Transform spawnPos;
    void Start() {
        isServed = false;
        cooking = false;
    }
    void Update() {
        if (cooking) {
            Debug.Log("cooking...");
            cookTime -= Time.deltaTime;
        } else if (bread != null) {
            evaluate(cookTime);
        }
    }
    void OnCollisionEnter(Collision col) {
        Debug.Log("collision detected!");
        if (col.gameObject.name.Equals("bread")) {
            Debug.Log("we found bread");
            if (bread == null) {
                bread = (Food)CookingProgress.ingredients.GetValue(2);
                if (bread.getChopped()) {
                    Debug.Log("bread is ready");
                    ingCount++;
                    breadObj = col.gameObject;
                    breadObj.gameObject.SetActive(false);
                    cooking = true;
                } 
            }
        } 
        Debug.Log(ingCount);
    }

    public void giveBread() {
        if (breadObj == null) {
            return;
        }
        breadObj.gameObject.SetActive(true);
        breadObj.gameObject.transform.position = spawnPos.position;
        cooking = false;
    }

    private void evaluate(float time) {
        if (bread == null) {
            return;
        }
        if (time > 2f) {
            bread.setStatus(-1);
        } else if (time < 2f) {
           bread.setStatus(1);
        } else {
            bread.setStatus(0);
        }
    }
}

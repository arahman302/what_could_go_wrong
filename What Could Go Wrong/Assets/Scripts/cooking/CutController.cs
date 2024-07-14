using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutController : MonoBehaviour
{
    // private Food fish;
    // private Food garlic;
    // private Food pepper;
    // private Food lemon;
    private Food currentFood;
    private GameObject currentFoodObject;
    [SerializeField] private Transform cuttingPos;
    [SerializeField] private bool isCutting;
    [SerializeField] private int chopsLeft;
    // Start is called before the first frame update
    void Start()
    {
        isCutting = false;
        chopsLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                chopsLeft--;
                Debug.Log("chop!" + chopsLeft);
            }
            if (chopsLeft <= 0) {
                currentFood.chop();
                chopsLeft = 5;
                isCutting = false;
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().updateGrab(true);
                currentFood = null;
                currentFoodObject = null;
                Debug.Log("done!");
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("fish")) {
            currentFood = (Food)CookingProgress.ingredients.GetValue(1);
            if (!currentFood.getChopped()) {
                currentFoodObject = col.gameObject;
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().updateGrab(false);
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().Drop();
                currentFoodObject.gameObject.transform.position = new Vector3(cuttingPos.position.x, cuttingPos.position.y, cuttingPos.position.z);
                currentFoodObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                isCutting = true;
            } else {
            currentFood = null;
            currentFoodObject = null;
            }  
        } else if (col.gameObject.name.Equals("garlic")) {
            currentFood = (Food)CookingProgress.ingredients.GetValue(3);
            if (!currentFood.getChopped()) {
                currentFoodObject = col.gameObject;
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().updateGrab(false);
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().Drop();
                currentFoodObject.gameObject.transform.position = new Vector3(cuttingPos.position.x, cuttingPos.position.y, cuttingPos.position.z);
                currentFoodObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                isCutting = true;
            } else {
            currentFood = null;
            currentFoodObject = null;
            }  
        } else if (col.gameObject.name.Equals("pepper")) {
            currentFood = (Food)CookingProgress.ingredients.GetValue(4);
            if (!currentFood.getChopped()) {
                currentFoodObject = col.gameObject;
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().updateGrab(false);
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().Drop();
                currentFoodObject.gameObject.transform.position = new Vector3(cuttingPos.position.x, cuttingPos.position.y, cuttingPos.position.z);
                currentFoodObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                isCutting = true;
            } else {
            currentFood = null;
            currentFoodObject = null;
            }  
        } else if (col.gameObject.name.Equals("lemon")) {
            currentFood = (Food)CookingProgress.ingredients.GetValue(5);
            if (!currentFood.getChopped()) {
                currentFoodObject = col.gameObject;
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().updateGrab(false);
                currentFoodObject.gameObject.GetComponent<ObjectGrabbable>().Drop();
                currentFoodObject.gameObject.transform.position = new Vector3(cuttingPos.position.x, cuttingPos.position.y, cuttingPos.position.z);
                currentFoodObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                isCutting = true;
            } else {
            currentFood = null;
            currentFoodObject = null;
            }  
        }
    }
}

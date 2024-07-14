using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int isCooked; //-1: uncooked, 0: cooked, 1: overcooked
    [SerializeField] private string id;
    [SerializeField] private bool needsChopping;
    [SerializeField] private bool isChopped;
    [SerializeField] private GameObject tool;
    [SerializeField] private bool isServed;
    public Food(string id, bool chop, GameObject tool) {
        isCooked = -1;
        this.id = id;
        needsChopping = chop;
        isChopped = false;
        this.tool = tool;
        isServed = false;
    }

    public void serve() {
        isServed = true;
    }
    public bool getServed() {
        return isServed;
    }
    public string getID() {
        return id;
    }

    public void setStatus(int status) {
        isCooked = status;
    }

    public int getStatus() {
        return isCooked;
    }

    public GameObject getTool() {
        return tool;
    }

    public bool getChopped() {
        return (needsChopping ? isChopped : true);
    }
    public void chop() {
        if (!needsChopping) {
            return;
        } else {
            isChopped = true;
        }
    }
}

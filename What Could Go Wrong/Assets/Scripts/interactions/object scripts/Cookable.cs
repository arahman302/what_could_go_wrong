using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Cookable
{
    List<GameObject> acceptableItems {get; set;}
    void cook();
    int finishedCooking();
    void displayProgress();
}

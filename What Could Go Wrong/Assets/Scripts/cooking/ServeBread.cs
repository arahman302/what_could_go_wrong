using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeBread : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name.Equals("plate")) {
            serve();
            this.gameObject.SetActive(false);
        }
    }

    private void serve() {
        ((Food)CookingProgress.ingredients.GetValue(2)).serve();
    }
}

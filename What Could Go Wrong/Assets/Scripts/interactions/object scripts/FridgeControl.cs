using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeControl : MonoBehaviour
{
    private bool opened = false;

    public void Open() {
        opened = true;
        //this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        this.gameObject.transform.Rotate(0, -90, 0, Space.Self);
    }

    public void Close() {
        opened = false;
        //this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.gameObject.transform.Rotate(0, 90, 0, Space.Self);
    }
    public bool isOpen() {
        return opened;
    }
}

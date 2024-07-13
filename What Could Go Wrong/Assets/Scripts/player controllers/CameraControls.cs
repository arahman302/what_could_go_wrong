using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //mouse sensitivites
    public float sensX;
    public float sensY;

    //camera positioning
    public Transform orientation;
    float xRotation;
    float yRotation;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            //mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
            //update current rotation
            yRotation += mouseX;
            xRotation -= mouseY;

            //prevent neck breaking
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation,0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform grabPos;
    private ObjectGrabbable grabbedObject;
    [SerializeField] private CameraControls camera;
    [SerializeField] private float rotationSensitivity;

    private void Update() {
        //pick up and drop
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (grabbedObject == null) {
                if (Physics.Raycast(cameraPos.position, cameraPos.forward, out RaycastHit raycastHit, maxDistance, layerMask)) {
                    //Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out grabbedObject)) {
                        grabbedObject.Grab(grabPos);
                        //Debug.Log(objectGrabbable);
                    }
                }
            } else {
                grabbedObject.Drop();
                grabbedObject = null;
            }
        }
        //rotation
        if (grabbedObject != null && Input.GetKey(KeyCode.R)) {
            camera.canMove = false;
            float rotateX = Input.GetAxis("Mouse X") * rotationSensitivity;
            float rotateY = Input.GetAxis("Mouse Y") * rotationSensitivity;
            grabbedObject.transform.Rotate(Vector3.down, rotateX);
            grabbedObject.transform.Rotate(Vector3.right, rotateY);
        } else {
            camera.canMove = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabPoint;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private bool canGrab;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        canGrab = true;
    }

    public void Grab(Transform grabPos) {
        if (!canGrab) {
            return;
        }
        grabPoint = grabPos;
        rb.useGravity = false;
    }

    public void Drop() {
        grabPoint = null;
        rb.useGravity = true;
    }

    private void FixedUpdate() {
        if (grabPoint != null) {
            Vector3 target = Vector3.Lerp(transform.position, grabPoint.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(target);
        }
    }

    public void updateGrab(bool grab) {
        canGrab = grab;
    }
}

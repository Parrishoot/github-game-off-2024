using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private Vector3 lastPos;

    private void OnTriggerEnter(Collider other) {
        Rigidbody rigidbody= other.GetComponent<Rigidbody>();

        if (rigidbody != null) {
            rigidbodies.Add(rigidbody);
        }
    }

    private void OnTriggerExit(Collider other) {
        Rigidbody rigidbody= other.GetComponent<Rigidbody>();

        if (rigidbody != null) {
            rigidbodies.Remove(rigidbody);
        }
    }

    private void FixedUpdate() {
        
        foreach(Rigidbody rigidbody in rigidbodies) {
            rigidbody.MovePosition(rigidbody.position + (transform.position - lastPos));
        }

        lastPos = transform.position;
    }

}

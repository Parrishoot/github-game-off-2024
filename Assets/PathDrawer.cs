using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Transform[] children = GetComponentsInChildren<Transform>();

        for(int i = 1; i <= children.Length; i++) {
            Gizmos.DrawLine(children[i % children.Length].position, children[i-1].position);
        }       
    }
}

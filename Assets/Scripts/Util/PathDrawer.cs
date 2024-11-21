using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        List<Transform> children = GetComponentsInChildren<Transform>().ToList();
        children = children.Where(x => transform != x.transform).ToList();

        for(int i = 1; i <= children.Count; i++) {
            Gizmos.DrawLine(children[i % children.Count].position, children[i-1].position);
        }       
    }
}

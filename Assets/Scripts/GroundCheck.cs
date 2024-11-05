using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private Collider groundCollider;

    private List<GameObject> groundObjects = new List<GameObject>();

    public bool OnGround() {
        return groundObjects.Count != 0;
    }

    
    private void OnTriggerEnter(Collider other) {
        if(LayerMaskUtil.InLayerMask(other.gameObject.layer, LayerMaskUtil.GetGroundMask())) {
            groundObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        groundObjects.Remove(other.gameObject);
    }
}

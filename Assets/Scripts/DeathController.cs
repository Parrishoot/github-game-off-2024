using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    void Start() {
        SceneTransitionManager.Instance.OnTransitionOutFinished += () => TransitionIn();
    }

    private void TransitionIn()
    {
        SceneTransitionManager.Instance.TransitionIn();
    }

    void OnTriggerEnter(Collider other) {   
        
        if(other.gameObject.GetComponent<RespawnController>() != null) {
            SceneTransitionManager.Instance.TransitionOut();
            return;
        }

        PackageManager package = other.GetComponent<PackageManager>();
        if(package != null) {
            Debug.Log("Got here!");
            package.Lose();
            return;
        }
    }
}

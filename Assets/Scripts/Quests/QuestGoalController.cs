using System;
using UnityEngine;
using UnityEngine.ProBuilder;

public class QuestGoalController : MonoBehaviour
{   
    public Action PackageDelivered { get; set; }

    private PackageManager targetPackage;

    public void SetTargetPackage(PackageManager targetPackage) {
        this.targetPackage = targetPackage;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.Equals(targetPackage.gameObject)) {
            PackageDelivered.Invoke();
            targetPackage.DeliverPackage();
            gameObject.SetActive(false);
        }

    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PackageWatcher : MonoBehaviour
{
    public Action OnPackageSpotted { get; set; }

    protected PackageManager TargetPackage { get; private set; }

    public virtual void SetTargetPackage(PackageManager targetPackage) {
        TargetPackage = targetPackage;
    }

    private void OnTriggerEnter(Collider other) {
        
        if(TargetPackage == null) {
            return;
        }

        PackageManager otherPackage = other.GetComponent<PackageManager>();

        if(TargetPackage.Equals(otherPackage)) {
            ProcessPackageSpotted();
            OnPackageSpotted?.Invoke();
            return;
        }

        PlayerPackagePickupController pickupController = other.GetComponentInChildren<PlayerPackagePickupController>();

        if(pickupController != null && pickupController.CurrentPackage != null && TargetPackage.Equals(pickupController.CurrentPackage.Manager)) {
            ProcessPackageSpotted();
            OnPackageSpotted?.Invoke();
            return;
        }

    }

    protected abstract void ProcessPackageSpotted();
}

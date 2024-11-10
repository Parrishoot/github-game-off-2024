using System;
using UnityEngine;

public abstract class PackageWatcher : MonoBehaviour
{
    public Action OnPackageSpotted { get; set; }

    protected PackageManager TargetPackage { get; private set; }

    public virtual void SetTargetPackage(PackageManager targetPackage) {
        TargetPackage = targetPackage;
    }

    private void OnTriggerEnter(Collider other) {
        
        PackageManager otherPackage = other.GetComponent<PackageManager>();

        if(otherPackage == null) {
            return;
        }

        if(otherPackage.Equals(TargetPackage)) {
            ProcessPackageSpotted();
            OnPackageSpotted?.Invoke();
        }

    }

    protected abstract void ProcessPackageSpotted();
}

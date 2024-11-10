using System;
using UnityEngine;

public class QuestGoalController : PackageWatcher
{   
    public override void SetTargetPackage(PackageManager targetPackage)
    {
        base.SetTargetPackage(targetPackage);

        TargetPackage.OnPickup += Activate;

        TargetPackage.OnDrop += Deactivate;
        TargetPackage.OnSpotted += Deactivate;
    }

    protected override void ProcessPackageSpotted()
    {
        TargetPackage.DeliverPackage();
    }

    private void Activate() {
        gameObject.SetActive(true);
    }

    private void Deactivate() {
        gameObject.SetActive(false);
    }
}
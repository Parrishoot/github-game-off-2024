using System;
using UnityEngine;

public class QuestGoalController : PackageWatcher
{   
    [SerializeField]
    private MeshRenderer model;

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
        model.enabled = true;
    }

    private void Deactivate() {
        model.enabled = false;
    }
}
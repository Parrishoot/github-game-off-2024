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

        TargetPackage.OnBounce += Deactivate;
        TargetPackage.OnSpotted += Deactivate;
        TargetPackage.OnLost += Deactivate;
        SceneTransitionManager.Instance.OnTransitionOutFinished += Deactivate;
    }

    protected override void ProcessPackageSpotted()
    {
        TargetPackage.DeliverPackage();
    }

    private void Activate() {
        model.enabled = true;
        ArrowController.Instance.SetActiveGoal(this);
    }

    private void Deactivate() {
        model.enabled = false;
        ArrowController.Instance.Reset();
    }
}
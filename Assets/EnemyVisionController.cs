using UnityEngine;

public class EnemyVisionController : PackageWatcher
{
    protected override void ProcessPackageSpotted()
    {
        // TODO: ADD BETTER FEEDBACK HERE
        TargetPackage.DeliverPackage();
    }
}

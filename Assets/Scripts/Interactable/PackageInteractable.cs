
using UnityEngine;

public class PackageInteractable : MonoBehaviour, IInteractable
{
    [field:SerializeReference]
    public Rigidbody Rigidbody;

    public void Interact()
    {
        PlayerPackagePickupController.Instance.Pickup(this);
    }
}

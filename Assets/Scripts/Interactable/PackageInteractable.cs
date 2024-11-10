
using System;
using UnityEngine;

public class PackageInteractable : MonoBehaviour, IInteractable
{
    [field:SerializeReference]
    public Rigidbody Rigidbody;

    public Action OnPickup { get; set; }

    public void Interact()
    {
        PlayerPackagePickupController.Instance.Pickup(this);
    }

    public void PickedUp() {
        OnPickup?.Invoke();
    }
}

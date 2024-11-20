
using System;
using UnityEngine;

public class PackageInteractable : MonoBehaviour, IInteractable
{
    [field:SerializeReference]
    public Rigidbody Rigidbody;

    [field:SerializeField]
    public PackageManager Manager { get; private set; }

    public Action OnPickup { get; set; }

    public void Interact()
    {
        PlayerPackagePickupController.Instance.Pickup(this);
    }

    public void PickedUp() {
        Manager.OnPickup?.Invoke();
    }
}

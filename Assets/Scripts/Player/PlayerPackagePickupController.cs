using UnityEngine;
using DG.Tweening;
using System;

public class PlayerPackagePickupController : Singleton<PlayerPackagePickupController>
{
    [SerializeField]
    private Rigidbody playerRigidbody;

    [SerializeField]
    private float throwForce = 10f;

    [SerializeField]
    private GameObject packageModel;
   
    public PackageInteractable CurrentPackage { get; private set; }

    public Action<PackageManager> OnPackagePickup;

    private bool throwNextFixedUpdate = false;

    public void Pickup(PackageInteractable packageInteractable) {

        if(CurrentPackage != null) {
            return;
        } 

        packageModel.SetActive(true);

        CurrentPackage = packageInteractable;
        CurrentPackage.PickedUp();

        CurrentPackage.gameObject.SetActive(false);
        CurrentPackage.transform.SetParent(transform, false);
        CurrentPackage.transform.localPosition = Vector3.zero;

        CurrentPackage.Manager.OnSpotted += () => {
            packageModel.SetActive(false);
            CurrentPackage = null;
        };

        OnPackagePickup?.Invoke(CurrentPackage.Manager);
        InteractTextController.Instance.Disable();
    }

    private void SetupRigidbodyHold() {
        CurrentPackage.Rigidbody.freezeRotation = true;
        CurrentPackage.Rigidbody.useGravity = false;
    }

    public void Throw() {
        if(CurrentPackage != null) {
            throwNextFixedUpdate = true;
        }
    }

    public void Update() {
        
        // TODO: Map this to actual input
        if(Input.GetKeyDown(KeyCode.Q)) {
            Throw();
        }
    }

    private void FixedUpdate() {
        
        if(CurrentPackage == null) {
            return; 
        }

        if(!throwNextFixedUpdate) {
            CurrentPackage.Rigidbody.linearVelocity = playerRigidbody.linearVelocity;
            return;
        }

        CurrentPackage.gameObject.SetActive(true);
        packageModel.SetActive(false);

        throwNextFixedUpdate = false;

        CurrentPackage.Rigidbody.freezeRotation = false;
        CurrentPackage.Rigidbody.useGravity = true;

        CurrentPackage.Rigidbody.AddForce(throwForce * CameraController.Instance.GetLookingDirection(), ForceMode.Impulse);
        CurrentPackage.Manager.OnDrop?.Invoke();

        CurrentPackage = null;
    }
}

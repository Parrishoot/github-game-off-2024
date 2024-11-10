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
    private float snapTime = .5f;

    private PackageInteractable currentPackage;

    private bool throwNextFixedUpdate = false;

    public void Pickup(PackageInteractable packageInteractable) {

        if(currentPackage != null) {
            return;
        } 

        currentPackage = packageInteractable;
        currentPackage.PickedUp();

        currentPackage.Rigidbody.DORotate(Vector3.zero, snapTime).SetEase(Ease.InOutCubic);  
        
        currentPackage
            .Rigidbody
            .DOMove(transform.position, snapTime)
            .SetEase(Ease.InOutCubic)
            .OnComplete(SetupRigidbodyHold);

    }

    private void SetupRigidbodyHold() {
        currentPackage.Rigidbody.freezeRotation = true;
        currentPackage.Rigidbody.useGravity = false;
    }

    public void Throw() {
        throwNextFixedUpdate = true;
    }

    public void Update() {
        
        // TODO: Map this to actual input
        if(Input.GetKeyDown(KeyCode.Q)) {
            Throw();
        }
    }

    private void FixedUpdate() {
        
        if(currentPackage == null) {
            return; 
        }

        if(!throwNextFixedUpdate) {
            currentPackage.Rigidbody.linearVelocity = playerRigidbody.linearVelocity;
            return;
        }

        throwNextFixedUpdate = false;

        currentPackage.Rigidbody.freezeRotation = false;
        currentPackage.Rigidbody.useGravity = true;

        currentPackage.Rigidbody.AddForce(throwForce * CameraController.Instance.GetLookingDirection(), ForceMode.Impulse);

        currentPackage = null;
    }
}

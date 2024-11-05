using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [field:SerializeReference]
    public Rigidbody Rigidbody { get; private set; }

    [SerializeField]
    private float jumpForce = 100f;

    [SerializeField]
    private float movementSpeed = 100f;

    [SerializeField]
    [Range(0, 1)]
    private float speedRampWeight = .5f;

    [SerializeField]
    [Range(1.1f, 3f)]
    private float sprintAdjustAmount = 1.5f;

    private Vector3 movementVector = Vector3.zero;

    private bool jumpedSinceLastFrame = false;

    private bool isSprinting = false;

    private void FixedUpdate() {
        
        // Use FixedUpdate when handling physics because it gets applied at a constant framerate
        // Also be sure to use Time.fixedDeltaTime instead of regular deltaTime
        Vector3 frameMovementVector = Vector3.zero;

        frameMovementVector += movementVector.x * cameraController.Pivot.transform.right;
        frameMovementVector += movementVector.z * cameraController.Pivot.transform.forward;

        Vector3 newMovement = Vector3.Lerp(Rigidbody.linearVelocity, frameMovementVector * Time.fixedDeltaTime * movementSpeed * GetSprintModifier(), speedRampWeight);
        Rigidbody.linearVelocity = new Vector3(newMovement.x, Rigidbody.linearVelocity.y, newMovement.z);

        if(jumpedSinceLastFrame) {
            Rigidbody.linearVelocity = new Vector3(Rigidbody.linearVelocity.x, 0f, Rigidbody.linearVelocity.z);
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        RestMovements();
    }

    public void Move(Vector3 movementVector) {
        this.movementVector = movementVector;
    }

    public void Jump() {
        this.jumpedSinceLastFrame = true;
    }

    public void SetSprinting(bool sprinting) {
        isSprinting = sprinting;
    }
    
    private void RestMovements() {
        this.movementVector = Vector3.zero;
        this.jumpedSinceLastFrame = false;
    }

    private float GetSprintModifier() {
        return this.isSprinting ? sprintAdjustAmount : 1f;
    }
}

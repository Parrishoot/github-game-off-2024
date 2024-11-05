using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [field:SerializeReference]
    public Rigidbody Rigidbody { get; private set; }

    public bool IsFalling { get; private set; } = false;

    [SerializeField]
    private float jumpForce = 100f;

    [SerializeField]
    private float wallJumpForce = 100f;

    [SerializeField]
    private float movementSpeed = 100f;

    [SerializeField]
    [Range(0, 1)]
    private float speedRampWeight = .5f;

    [SerializeField]
    [Range(1.1f, 3f)]
    private float sprintAdjustAmount = 1.5f;

    private Timer inputLockTimer = null;

    private Vector3 movementVector = Vector3.zero;

    private bool jumpedSinceLastFrame = false;

    private Vector3 wallJumpDirection = Vector3.zero;

    private bool isSprinting = false;

    private bool inputLock = false;

    void Update() {
        inputLockTimer?.DecreaseTime(Time.deltaTime);
    }

    private void FixedUpdate() {
        
        // Use FixedUpdate when handling physics because it gets applied at a constant framerate
        // Also be sure to use Time.fixedDeltaTime instead of regular deltaTime

        if(inputLock == false) {
            Vector3 newMovement = Vector3.Lerp(Rigidbody.linearVelocity, movementVector * Time.fixedDeltaTime * movementSpeed * GetSprintModifier(), speedRampWeight);
            Rigidbody.linearVelocity = new Vector3(newMovement.x, Rigidbody.linearVelocity.y, newMovement.z);
        }

        if(jumpedSinceLastFrame || !Vector3.zero.Equals(wallJumpDirection)) {
            Rigidbody.linearVelocity = new Vector3(Rigidbody.linearVelocity.x, 0f, Rigidbody.linearVelocity.z);
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(!Vector3.zero.Equals(wallJumpDirection)) {
            Rigidbody.AddForce(wallJumpDirection * wallJumpForce, ForceMode.Impulse);
        }

        IsFalling = Rigidbody.linearVelocity.y <= .001f;

        RestMovements();
    }

    public void Move(Vector3 movementVector) {
        this.movementVector = movementVector;
    }

    public void Jump() {
        this.jumpedSinceLastFrame = true;
    }

    public void WallJump(Vector3 direction) {
        this.wallJumpDirection = direction;

        inputLock = true;
        this.inputLockTimer = new Timer(.3f);
        this.inputLockTimer.OnTimerFinished += () => {
            inputLock = false;
        };
    }

    public void SetSprinting(bool sprinting) {
        isSprinting = sprinting;
    }
    
    private void RestMovements() {
        this.movementVector = Vector3.zero;
        this.jumpedSinceLastFrame = false;
        this.wallJumpDirection = Vector3.zero;
    }

    private float GetSprintModifier() {
        return this.isSprinting ? sprintAdjustAmount : 1f;
    }
}

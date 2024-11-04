using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private new Rigidbody rigidbody;

    [SerializeField]
    private float jumpForce = 100f;

    [SerializeField]
    private float movementSpeed = 100f;

    [SerializeField]
    [Range(0, 1)]
    private float speedRampWeight = .5f;

    private PlayerInputController playerInputController;

    private Vector3 movementVector = Vector3.zero;

    private bool jumpedSinceLastFrame = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInputController = new PlayerInputController();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: UPDATE THIS AND MOVE IT TO ITS OWN STATE MACHINE

        Vector3 inputVector = playerInputController.GetMovementVector();
        Vector3 movementVector = Vector3.zero;

        movementVector += inputVector.x * cameraController.Pivot.transform.right;
        movementVector += inputVector.z * cameraController.Pivot.transform.forward;

        Move(movementVector);

        if(playerInputController.GetJump()) {
            jumpedSinceLastFrame = true;
        }
    }


    private void FixedUpdate() {
        
        // Use FixedUpdate when handling physics because it gets applied at a constant framerate
        // Also be sure to use Time.fixedDeltaTime instead of regular deltaTime

        Vector3 newMovement = Vector3.Lerp(rigidbody.linearVelocity, movementVector * Time.fixedDeltaTime * movementSpeed, speedRampWeight);
        rigidbody.linearVelocity = new Vector3(newMovement.x, rigidbody.linearVelocity.y, newMovement.z);

        if(jumpedSinceLastFrame) {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, 0f, rigidbody.linearVelocity.z);
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        RestMovements();
    }

    public void Move(Vector3 movementVector) {
        this.movementVector = movementVector;
    }

    public void Jump() {
        this.jumpedSinceLastFrame = true;
    }

    private void RestMovements() {
        this.movementVector = Vector3.zero;
        this.jumpedSinceLastFrame = false;
    }
}

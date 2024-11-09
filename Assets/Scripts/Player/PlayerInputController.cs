using UnityEngine;

public class PlayerInputController: Singleton<PlayerInputController>
{
    [SerializeField]
    private CameraController cameraController;

    private bool movementEnabled = true;

    void Start() {
        DialogueManager.Instance.OnDialogueStart += DisableMovement;
        DialogueManager.Instance.OnDialogueFinish += EnableMovement;
    }

    public Vector3 GetMovementVector() {

        if(!movementEnabled) {
            return Vector3.zero;
        }

        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    public Vector3 GetCameraAdjustedInputVector() {
        
        Vector3 movementVector = Vector3.zero;

        movementVector += GetMovementVector().x * cameraController.Pivot.transform.right;
        movementVector += GetMovementVector().z * cameraController.Pivot.transform.forward;

        return movementVector;
    }

    public bool GetJump() {
        return movementEnabled && Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetSprint() {
        return movementEnabled && Input.GetKey(KeyCode.LeftShift);
    }

    public void DisableMovement() {
        movementEnabled = false;
    }

    public void EnableMovement() {
        movementEnabled = true;
    }
}

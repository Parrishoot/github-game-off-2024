using UnityEngine;

public class PlayerInputController: MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;

    public Vector3 GetMovementVector() {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    public Vector3 GetCameraAdjustedInputVector() {
        
        Vector3 movementVector = Vector3.zero;

        movementVector += GetMovementVector().x * cameraController.Pivot.transform.right;
        movementVector += GetMovementVector().z * cameraController.Pivot.transform.forward;

        return movementVector;
    }

    public bool GetJump() {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetSprint() {
        return Input.GetKey(KeyCode.LeftShift);
    }
}

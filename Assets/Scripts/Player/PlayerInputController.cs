using UnityEngine;

public class PlayerInputController
{
    [SerializeField]
    private CameraController cameraController;

    public Vector3 GetMovementVector() {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    public bool GetJump() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

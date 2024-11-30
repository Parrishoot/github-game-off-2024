using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    // You need this to see properties in the inspector
    [field:SerializeReference]
    public Transform Pivot { get; private set; }


    void Start() {
        LockCursor();

        SettingsPanelController.Instance.OnClose += LockCursor;
        SettingsPanelController.Instance.OnOpen += UnlockCursor;
    }

    // Update is called once per frame
    void Update()
    {
        Pivot.Rotate(Vector2.up * Input.GetAxis("Mouse X") * CameraSensitivityManager.Instance.Sensitivity * Time.deltaTime);
    }

    public Vector3 GetLookingDirection()
    {
        return Pivot.transform.forward;
    }

    public void LockCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

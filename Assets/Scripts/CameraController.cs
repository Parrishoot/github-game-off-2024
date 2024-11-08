using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField]
    private float sensitivity;

    // You need this to see properties in the inspector
    [field:SerializeReference]
    public Transform Pivot { get; private set; }


    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Pivot.Rotate(Vector2.up * Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
    }

    public Vector3 GetLookingDirection()
    {
        return Pivot.transform.forward;
    }
}

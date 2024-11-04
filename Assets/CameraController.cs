using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float sensitivity;

    // You need this to see properties in the inspector
    [field:SerializeReference]
    public Transform Pivot { get; private set; }


    // Update is called once per frame
    void Update()
    {
        Pivot.Rotate(Vector2.up * Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
    }
}

using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
    }
}

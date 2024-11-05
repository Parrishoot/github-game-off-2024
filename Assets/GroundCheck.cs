using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayerMask;

    [SerializeField]
    private Collider groundCollider;

    public bool OnGround { get; private set; }

    void Update() {
        Debug.Log(OnGround);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        OnGround = Physics.BoxCast(groundCollider.bounds.center, groundCollider.bounds.size / 2f, Vector3.down, out hit, transform.rotation, .1f);
    }
}

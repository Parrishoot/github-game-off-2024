using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private new Rigidbody rigidbody;

    private float threshold = 0.01f;

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("Running", Vector3.Distance(rigidbody.linearVelocity, Vector3.zero) > threshold);
    }
}

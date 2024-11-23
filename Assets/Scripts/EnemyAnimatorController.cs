using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Vector3 lastLoc;

    // Update is called once per frame
    void Update()
    {
        // Definitely a hack - don't judge me
        animator.SetBool("Running", transform.position != lastLoc);
        lastLoc = transform.position;
    }
}

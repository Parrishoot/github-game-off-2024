using DG.Tweening;
using UnityEngine;

public class IconAnimationController : MonoBehaviour
{
    [SerializeField]
    private float rotateAmount = 15f;

    [SerializeField]
    private float rotateTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localEulerAngles = Vector3.forward * rotateAmount * -1;
        transform.DOLocalRotate(Vector3.forward * rotateAmount, rotateTime)
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);
    }
}

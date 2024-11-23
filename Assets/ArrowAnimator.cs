using DG.Tweening;
using UnityEngine;

public class ArrowAnimator : MonoBehaviour
{
    [SerializeField]
    private float scaleAmount = .1f;

    [SerializeField]
    private float scaleTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOScale(transform.localScale + (transform.localScale * scaleAmount), scaleTime)
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);
    }
}

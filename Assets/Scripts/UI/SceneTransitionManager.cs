using System;
using DG.Tweening;
using UnityEngine;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    [SerializeField]
    private RectTransform maskTransform;

    [SerializeField]
    private float transitionTime = 1f;

    private const float MAX_SIZE = 1500f;

    public Action OnTransitionInFinished { get; set; }

    public Action OnTransitionOutFinished { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskTransform.sizeDelta = new Vector2(MAX_SIZE, MAX_SIZE);
        TransitionIn();
    }

    public void TransitionIn() {
        maskTransform
            .DOSizeDelta(new Vector2(0f, 0f), transitionTime)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() => {
                OnTransitionInFinished?.Invoke();
            });
    }

    public void TransitionOut() {
        maskTransform
            .DOSizeDelta(new Vector2(MAX_SIZE, MAX_SIZE), transitionTime)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() => {
                OnTransitionOutFinished?.Invoke();
            });
    }
}

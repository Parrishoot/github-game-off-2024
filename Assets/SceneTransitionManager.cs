using System;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    [SerializeField]
    private RectTransform maskTransform;

    [SerializeField]
    private float transitionTime = 1f;

    private const float MAX_SIZE = 1000f;

    public Action OnTransitionFinished { get; set; }

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
                OnTransitionFinished?.Invoke();
                OnTransitionFinished = null;
            });
    }

    public void TransitionOut() {
        maskTransform
            .DOSizeDelta(new Vector2(MAX_SIZE, MAX_SIZE), transitionTime)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() => {
                OnTransitionFinished?.Invoke();
                OnTransitionFinished = null;
            });
    }
}

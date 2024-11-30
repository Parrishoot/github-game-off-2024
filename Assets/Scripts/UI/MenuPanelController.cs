using System;
using DG.Tweening;
using UnityEngine;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = .3f;

    public bool IsOpen { get; set; } = false;

    public Action OnPanelOpen { get; set; }
    
    public Action OnPanelClosed { get; set; }

    void Start() {
        transform.localScale = Vector3.zero;
    }

    public void Open() {

        if(IsOpen) {
            return;
        }

        transform.DOScale(Vector3.one, transitionSpeed)
            .SetEase(Ease.InOutCubic)
            .SetUpdate(true);

        OnPanelOpen?.Invoke();

        IsOpen = true;
    }

    public void Close() {

        if(!IsOpen) {
            return;
        }

        transform.DOScale(Vector3.zero, transitionSpeed)
            .SetEase(Ease.InOutCubic)
            .SetUpdate(true);

        OnPanelClosed?.Invoke();

        IsOpen = false;
    }

    public void Toggle() {
        if(IsOpen) {
            Close();
        }
        else {
            Open();
        }
    }
}

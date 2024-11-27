using DG.Tweening;
using UnityEngine;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField]
    private float transitionSpeed = .3f;

    void Start() {
        transform.localScale = Vector3.zero;
    }

    public void Open() {
        transform.DOScale(Vector3.one, transitionSpeed).SetEase(Ease.InOutCubic);
    }

    public void Close() {
        transform.DOScale(Vector3.zero, transitionSpeed).SetEase(Ease.InOutCubic);
    }
}

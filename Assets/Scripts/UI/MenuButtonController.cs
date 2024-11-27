using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private float scaleSize = 1.2f;

    [SerializeField]
    private float scaleSpeed = .5f;

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private Color textHightlightColor;

    private Color textStartColor;

    void Start() {
        textStartColor = text.color;
    }
    
    public Action OnClick { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * scaleSize, scaleSpeed).SetEase(Ease.InOutCubic);
        text.DOColor(textHightlightColor, scaleSpeed).SetEase(Ease.InOutCubic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, scaleSpeed).SetEase(Ease.InOutCubic);
        text.DOColor(textStartColor, scaleSpeed).SetEase(Ease.InOutCubic);
    }
}

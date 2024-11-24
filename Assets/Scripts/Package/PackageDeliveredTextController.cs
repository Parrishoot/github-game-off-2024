using DG.Tweening;
using TMPro;
using UnityEngine;

public class PackageDeliveredTextController : Singleton<PackageDeliveredTextController>
{
    private const float OFFSCREEN_POS = 1600f;

    [SerializeField]
    private RectTransform packageTransform;

    [SerializeField]
    private RectTransform deliveredTransform;

    [SerializeField]
    private float totalTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reset();
    }

    public void ShowText() {
        
        packageTransform.anchoredPosition = new Vector2(-OFFSCREEN_POS, packageTransform.anchoredPosition.y);
        deliveredTransform.anchoredPosition = new Vector2(OFFSCREEN_POS, deliveredTransform.anchoredPosition.y);

        packageTransform.gameObject.SetActive(true);
        deliveredTransform.gameObject.SetActive(true);

        DOTween.Sequence()
            .Append(packageTransform.DOAnchorPosX(0f, totalTime / 4).SetEase(Ease.InOutCubic))
            .Join(deliveredTransform.DOAnchorPosX(0f, totalTime / 4).SetEase(Ease.InOutCubic))
            .AppendInterval(totalTime / 2)
            .Append(packageTransform.DOAnchorPosX(OFFSCREEN_POS, totalTime / 4).SetEase(Ease.InOutCubic))
            .Join(deliveredTransform.DOAnchorPosX(-OFFSCREEN_POS, totalTime / 4).SetEase(Ease.InOutCubic))
            .OnComplete(Reset)
            .Play();
    }

    private void Reset() {
        packageTransform.gameObject.SetActive(false);
        deliveredTransform.gameObject.SetActive(false);
    }
}

using DG.Tweening;
using TMPro;
using UnityEngine;

public class PackageDeliveredTextController : Singleton<PackageDeliveredTextController>
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private float fadeOutSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.alpha = 0;
    }

    public void ShowText() {
        text.alpha = 1f;
        DOTween.To(() => text.alpha, x => text.alpha = x, 0f, fadeOutSpeed).SetEase(Ease.InOutCubic);
    }
}

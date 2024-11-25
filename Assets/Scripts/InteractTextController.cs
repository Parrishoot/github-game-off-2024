using TMPro;
using UnityEngine;

public class InteractTextController : Singleton<InteractTextController>
{
    [SerializeField]
    private TMP_Text interactText;

    [SerializeField]
    private GameObject interactGameObject;

    void Start() {
        Disable();
    }

    public void SetText(string text) {
        interactText.text = text;
        interactGameObject.SetActive(true);
    }

    public void Disable() {
        interactGameObject.SetActive(false);
    }
}

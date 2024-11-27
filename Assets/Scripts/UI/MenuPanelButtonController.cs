using UnityEngine;

public class MenuPanelButtonController : MonoBehaviour
{
    [SerializeField]
    private MenuPanelController menuPanelController;

    [SerializeField]
    private MenuButtonController menuButtonController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuButtonController.OnClick += menuPanelController.Open;
    }
}

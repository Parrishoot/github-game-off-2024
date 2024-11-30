using System;
using UnityEngine;

public class SettingsPanelController : Singleton<SettingsPanelController>
{
    [SerializeField]
    public MenuPanelController settingsPanel;

    public Action OnOpen;

    public Action OnClose;

    void Start() {
        settingsPanel.OnPanelOpen += () => OnOpen?.Invoke();
        settingsPanel.OnPanelClosed += () => OnClose?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            settingsPanel.Toggle();
        }
    }
}

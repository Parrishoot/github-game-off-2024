using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupTimeScaleEventProcessors();   
    }

    private void SetupTimeScaleEventProcessors()
    {
        SettingsPanelController.Instance.OnOpen += () => Time.timeScale = 0;
        SettingsPanelController.Instance.OnClose += () => Time.timeScale = 1;
    }
}

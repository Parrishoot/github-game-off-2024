using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensitivityManager : Singleton<CameraSensitivityManager>
{

    [SerializeField]
    private float minSensitivity = 10f;

    [SerializeField]
    private float maxSensitivity = 500f;

    [SerializeField]
    private Slider slider;

    public float Sensitivity { get; private set; } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSensitivity(slider.value);
        slider.onValueChanged.AddListener((x) => SetSensitivity(x));
    }

    private void SetSensitivity(float sliderSensitivity) {
    Sensitivity =  Mathf.Lerp(minSensitivity, maxSensitivity, sliderSensitivity);
    }
}

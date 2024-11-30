using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    private const string FX_NAME = "fx_level";
    private const string MUSIC_NAME = "music_level";

    [SerializeField]
    private Slider fxSlider;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private AudioMixer masterMixer;

    void Start() {
        fxSlider.onValueChanged.AddListener((x) => VolumeChange(FX_NAME, x));
        musicSlider.onValueChanged.AddListener((x) => VolumeChange(MUSIC_NAME, x));

        VolumeChange(FX_NAME, fxSlider.value);
        VolumeChange(MUSIC_NAME, musicSlider.value);
    }

    private void VolumeChange(string name, float level)
    {
        masterMixer.SetFloat(name, Mathf.Log(level) * 20);
    }
}

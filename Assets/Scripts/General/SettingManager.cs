using UnityEngine;
using UnityEngine.UI;

public  class  SettingManager : MonoBehaviour
{
    [SerializeField] private SettingSO audioSettings;

    [Header("Sliders")]
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    private void Awake()
    {
        audioSettings.LoadVolumes();
    }

    private void Start()
    {
        sliderMaster.value = audioSettings.GetMasterVolume();
        sliderMusic.value = audioSettings.GetMusicVolume();
        sliderSFX.value = audioSettings.GetSFXVolume();

        sliderMaster.onValueChanged.AddListener(UpdateMasterVolume);
        sliderMusic.onValueChanged.AddListener(UpdateMusicVolume);
        sliderSFX.onValueChanged.AddListener(UpdateSFXVolume);

        UpdateMasterVolume(sliderMaster.value);
        UpdateMusicVolume(sliderMusic.value);
        UpdateSFXVolume(sliderSFX.value);
    }
    private void OnDestroy()
    {
        audioSettings.SaveVolumes();
    }
    private void OnApplicationQuit()
    {
        audioSettings.SaveVolumes();
    }
    private void UpdateMasterVolume(float value)
    {
        audioSettings.SetMasterVolume(value);
    }

    private void UpdateMusicVolume(float value)
    {
        audioSettings.SetMusicVolume(value);
    }

    private void UpdateSFXVolume(float value)
    {
        audioSettings.SetSFXVolume(value);
    }
}

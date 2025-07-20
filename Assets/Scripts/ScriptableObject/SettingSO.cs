using UnityEngine;
using UnityEngine.Audio;
using System.IO;

[CreateAssetMenu(fileName = "SettingSO", menuName = "Scriptable Objects/SettingSO")]
public class SettingSO : ScriptableObject
{
    [SerializeField] private AudioMixer mainMixer;

    [Header("Volume Key")]
    [SerializeField] private string masterKey;
    [SerializeField] private string musicKey;
    [SerializeField] private string sfxKey;

    [Header("Volume")]
    [Range(0f, 1f)][SerializeField] private float masterVolume;
    [Range(0f, 1f)][SerializeField] private float musicVolume;
    [Range(0f, 1f)][SerializeField] private float sfxVolume;

    private string filePath => Path.Combine(Application.persistentDataPath, "SettingSO.json");

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat(masterKey, Mathf.Log10(volume) * 20);
        SaveVolumes(); 
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat(musicKey, Mathf.Log10(volume) * 20);
        SaveVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat(sfxKey, Mathf.Log10(volume) * 20);
        SaveVolumes();
    }

    public void LoadVolumes()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SettingJSON data = JsonUtility.FromJson<SettingJSON>(json);

            masterVolume = data.masterVolume;
            musicVolume = data.musicVolume;
            sfxVolume = data.sfxVolume;
        }

        SetMasterVolume(masterVolume);
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    public void SaveVolumes()
    {
        SettingJSON data = new SettingJSON(masterVolume,musicVolume,sfxVolume);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public float GetMasterVolume() => masterVolume;
    public float GetMusicVolume() => musicVolume;
    public float GetSFXVolume() => sfxVolume;
}

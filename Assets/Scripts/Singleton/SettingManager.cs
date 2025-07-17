using System;
using System.IO;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static Action<SettingJSON> OnSettingsLoaded;
    public static Func<SettingJSON> OnSettingsRequest;

    private SettingJSON currentSettings;
    private string filePath;
    private string json;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "settings.json");
        Load();
        OnSettingsLoaded?.Invoke(currentSettings);
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        currentSettings = OnSettingsRequest.Invoke();
        json = JsonUtility.ToJson(currentSettings, true);
        File.WriteAllText(filePath, json);
    }

    private void Load()
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            currentSettings = JsonUtility.FromJson<SettingJSON>(json);
        }
        else
        {
            currentSettings = new SettingJSON(); 
        }
    }
}

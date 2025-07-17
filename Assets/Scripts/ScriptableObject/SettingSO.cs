using UnityEngine;

[CreateAssetMenu(fileName = "SettingSO", menuName = "Scriptable Objects/SettingSO")]
public class SettingSO : ScriptableObject
{
    private SettingJSON currentSettings;
    private void OnEnable()
    {
        SettingManager.OnSettingsLoaded += SetSettings;
        SettingManager.OnSettingsRequest += GetSettings;
    }
    private void OnDisable()
    {
        SettingManager.OnSettingsLoaded -= SetSettings;
        SettingManager.OnSettingsRequest -= GetSettings;
    }
    private void SetSettings(SettingJSON config)
    {
        currentSettings =  config;
    }
    private SettingJSON GetSettings()
    {
        return currentSettings;
    }

}

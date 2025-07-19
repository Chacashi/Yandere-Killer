using UnityEngine;

[CreateAssetMenu(fileName = "SettingSO", menuName = "Scriptable Objects/SettingSO")]
public class SettingSO : ScriptableObject
{
    public SettingJSON currentSettings;
    private void SetSettings(SettingJSON config)
    {
        currentSettings =  config;
    }
    private SettingJSON GetSettings()
    {
        return currentSettings;
    }
}

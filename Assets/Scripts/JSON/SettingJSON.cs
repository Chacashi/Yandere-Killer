using UnityEngine;
[System.Serializable]
public class SettingJSON
{
    [Range(0, 1)] public float master;
    [Range(0, 1)] public float music;
    [Range(0, 1)] public float sfx;
    [Range(0, 1)] public float sensibility;
    public SettingJSON()
    {
        this.master = 1;
        this.music = 1;
        this.sfx = 1;
        this.sensibility = 1;
    }
    public SettingJSON(float master, float music, float sfx, float sensibility)
    {
        this.master = master;
        this.music = music;
        this.sfx = sfx;
        this.sensibility = sensibility;
    }
}

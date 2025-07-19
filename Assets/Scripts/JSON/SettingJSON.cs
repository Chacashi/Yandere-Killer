using UnityEngine;
[System.Serializable]
public class SettingJSON
{
    [Range(0, 1)] public float master;
    [Range(0, 1)] public float music;
    [Range(0, 1)] public float sfx;
    public float sensibility;
    public SettingJSON(float master, float music, float sfx, float sensibility)
    {
        this.master = master;
        this.music = music;
        this.sfx = sfx;
        this.sensibility = sensibility;
    }
}

using UnityEngine;
[System.Serializable]
public class SettingJSON
{
    [Range(0, 1)] public float masterVolume;
    [Range(0, 1)] public float musicVolume;
    [Range(0, 1)] public float sfxVolume;
    [Range(0, 1)] public float sensibility;

    public SettingJSON(float master, float music, float sfx)
    {
        this.masterVolume = master;
        this.musicVolume = music;
        this.sfxVolume = sfx;
        //this.sensibility = sensibility;
    }
}

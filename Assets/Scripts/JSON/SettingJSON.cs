using UnityEngine;
[System.Serializable]
public class SettingJSON
{
    [Range(0, 1)] public float masterVolume;
    [Range(0, 1)] public float musicVolume;
    [Range(0, 1)] public float sfxVolume;

    [Range(0, 1)] public float sensibilityHorizontal;
    [Range(0, 1)] public float sensibilityVertical;

    public SettingJSON(float master, float music, float sfx,float sensibilityHorizontal,float sensibilityVertical)
    {
        this.masterVolume = master;
        this.musicVolume = music;
        this.sfxVolume = sfx;
        this.sensibilityHorizontal = sensibilityHorizontal;
        this.sensibilityVertical = sensibilityVertical;
    }
}

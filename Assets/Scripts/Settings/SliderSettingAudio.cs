using UnityEngine;
using UnityEngine.Audio;

public class SliderSettingAudio : SliderSetting
{
    private enum Option
    {
        Master,
        Music,
        SFX
    }
    [Header("Option")]
    [SerializeField] private Option option;

    [Header("Audio")]
    [SerializeField] private AudioMixer mainMixer;
    private float volume;

    private void SaveInSettingSO(float value)
    {
        switch (option)
        {
            case Option.Master:

                break;
            case Option.Music:

                break;
            case Option.SFX:

                break;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
public abstract class SliderSetting : MonoBehaviour
{
    protected Slider mySlider;

    [Header("SettingSO")]
    [SerializeField] protected SettingSO setting;

    protected virtual void Awake()
    {
        mySlider = GetComponent<Slider>();
    }
    protected virtual void Start()
    {
        //ConfigureSliderListener();
    }
    //protected virtual void ConfigureSliderListener()
    //{
    //    switch (option)
    //    {
    //        case Option.Master:
    //            mySlider.onValueChanged.AddListener(value => UpdateValueSliderAudio(value, "master"));
    //            break;
    //        case Option.Music:
    //            mySlider.onValueChanged.AddListener(value => UpdateValueSliderAudio(value, "music"));
    //            break;
    //        case Option.SFX:
    //            mySlider.onValueChanged.AddListener(value => UpdateValueSliderAudio(value, "sfx"));
    //            break;
    //    }
    //}
    //private void UpdateValueSliderAudio(float value,string key)
    //{
    //    volume = Mathf.Clamp(value, 0.0001f, 1f);
    //    mainMixer.SetFloat(key, Mathf.Log10(volume) * 20);
    //    SaveInSettingSO(value);
    //}
   
}

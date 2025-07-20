using UnityEngine;
using UnityEngine.UI;

public abstract class SettingSliderBase : MonoBehaviour
{
    protected Slider slider;
    [SerializeField] protected SettingSO settingSO;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    protected virtual void Start()
    {
        slider.onValueChanged.AddListener(OnSliderChanged);
        InitSliderValue();
    }

    protected abstract void OnSliderChanged(float value);
    protected abstract void InitSliderValue();
}

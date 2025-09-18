using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string mixerParameter = "ExposedParameterName";

    [Header("UI Elements")]
    [SerializeField] private Slider volumeSlider;

    [Header("Volume Settings")]
    [SerializeField] private float defaultVolume = 0.8f;
    [SerializeField] private float minVolume = 0.0001f;
    [SerializeField] private float maxVolume = 1f;

    [Header("Save Settings")]
    [SerializeField] private string playerPrefsKey = "VolumeLevel";
    [SerializeField] private bool saveSettings = true;

    private const float MIN_DECIBELS = -80f;
    private const float DECIBELS_CONVERSION_FACTOR = 20f;
    private const float VOLUME_THRESHOLD = 0.0001f;

    private void Start()
    {
        InitializeSlider();
    }

    private void OnValidate()
    {
        minVolume = Mathf.Max(0.0001f, minVolume);
        maxVolume = Mathf.Max(minVolume, maxVolume);
        defaultVolume = Mathf.Clamp(defaultVolume, minVolume, maxVolume);
    }

    private void OnDestroy()
    {
        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(SliderChanged);
    }

    public void SetVolumeLevel(float volume)
    {
        volume = Mathf.Clamp(volume, minVolume, maxVolume);

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
        }
        else
        {
            SetVolume(volume);

            if (saveSettings)
            {
                PlayerPrefs.SetFloat(playerPrefsKey, volume);
                PlayerPrefs.Save();
            }
        }
    }

    public void SetSaveEnabled(bool enabled) =>
        saveSettings = enabled;

    public void ResetToDefault() =>
        SetVolumeLevel(defaultVolume);

    private void InitializeSlider()
    {
        if (volumeSlider == null)
        {
            volumeSlider = GetComponent<Slider>();
        }

        if (volumeSlider != null)
        {
            volumeSlider.minValue = minVolume;
            volumeSlider.maxValue = maxVolume;
        }

        float savedVolume = saveSettings ? PlayerPrefs.GetFloat(playerPrefsKey, defaultVolume) : defaultVolume;

        SetVolume(savedVolume);

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SliderChanged);
        }
    }

    private void SliderChanged(float value)
    {
        SetVolume(value);

        if (saveSettings)
        {
            PlayerPrefs.SetFloat(playerPrefsKey, value);
            PlayerPrefs.Save();
        }
    }

    private void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            float volumeInDecibels = ConvertLinearToDecibels(volume);
            audioMixer.SetFloat(mixerParameter, volumeInDecibels);
        }
    }

    private float ConvertLinearToDecibels(float linearVolume)
    {
        if (linearVolume <= VOLUME_THRESHOLD)
        {
            return MIN_DECIBELS;
        }

        return Mathf.Log10(linearVolume) * DECIBELS_CONVERSION_FACTOR;
    }
}
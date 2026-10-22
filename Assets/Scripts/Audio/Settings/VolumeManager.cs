using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider ambVolSlider, masVOlSlider, musVolSlider, sfxVolSlider;

    private void Start()
    {
        AmbienceVolume(1);
        ambVolSlider.value = 1f;

        MasterVolume(1);
        masVOlSlider.value = 1f;

        MusicVolume(0.5f);
        musVolSlider.value = 0.5f;

        SoundFXVolume(1);
        sfxVolSlider.value = 1f;
    }
    public void AmbienceVolume(float volume)
    {
        float logVol = Mathf.Log(volume) * 20;
        audioMixer.SetFloat("AmbienceVolume", logVol);
    }
    public void MasterVolume(float volume)
    {
        float logVol = Mathf.Log(volume) * 20;
        audioMixer.SetFloat("MasterVolume", logVol);
    }
    public void MusicVolume(float volume)
    {
        float logVol = Mathf.Log(volume) * 20;
        audioMixer.SetFloat("MusicVolume", logVol);
    }
    public void SoundFXVolume(float volume)
    {
        float logVol = Mathf.Log(volume) * 20;
        audioMixer.SetFloat("SoundFXVolume", logVol);
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        AmbienceVolume(1);
        MasterVolume(1);
        MusicVolume(1);
        SoundFXVolume(1);
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

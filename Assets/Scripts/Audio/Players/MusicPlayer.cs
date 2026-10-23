using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

public class MusicPlayer : SingletonBehaviour<MusicPlayer>
{
    [SerializeField] private AudioClip[] mainMenuMusicClips;
    [SerializeField] private AudioClip[] gameSceneMusicClips;
    private AudioClip[] currentMusicClipsCollection;

    [SerializeField] private AudioSource musicSource;

    private int nextClipIndex;

    private float musicClipTime;
    private float currentClipLength;
    private AudioClip currentClip;


    [SerializeField] InputAction testSwitchSongAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchCollection(0, 0, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        musicClipTime -= Time.deltaTime;

        if (musicClipTime <= 0)
        {
            if (nextClipIndex == currentMusicClipsCollection.Length)
                nextClipIndex = 0;

            SwitchSong(nextClipIndex, 8f);
        }

        if (testSwitchSongAction.WasPressedThisFrame())
        {
            if (nextClipIndex == currentMusicClipsCollection.Length)
                nextClipIndex = 0;

            SwitchSong(nextClipIndex, 8f);
        }
    }
    private void InitMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        currentClip = clip;

        currentClipLength = clip.length;
        musicClipTime = currentClipLength;

        musicSource.Play();

        nextClipIndex++;
    }
    private IEnumerator EaseInSong(AudioClip nextClip, float easeTime)
    {
        musicSource.Stop();
        float endVolume = musicSource.volume;
        float startVolume = 0.15f;
        musicSource.volume = startVolume;

        InitMusic(nextClip);

        while (musicSource.volume < endVolume)
        {
            musicSource.volume += Time.deltaTime / easeTime;
            
            yield return null;
        }
    }
    public void SwitchSong(int musicClipIndex, float easingTime)
    {
        if (nextClipIndex == currentMusicClipsCollection.Length)
            nextClipIndex = 0;
        StartCoroutine(EaseInSong(currentMusicClipsCollection[musicClipIndex], easingTime));
    }
    public void SwitchCollection(int sceneIndex, int clipIndex, float easingTime)
    {
        nextClipIndex = 0;
        switch (sceneIndex)
        {
            case 0:
                    currentMusicClipsCollection = mainMenuMusicClips;
                    SwitchSong(clipIndex, easingTime);
                    break;
            case 1:
                    currentMusicClipsCollection = gameSceneMusicClips;
                    SwitchSong(clipIndex, easingTime);
                    break;
            default:
                break;
        }
    }
    public override void Instantiate()
    {
        testSwitchSongAction.Enable();
    }
}

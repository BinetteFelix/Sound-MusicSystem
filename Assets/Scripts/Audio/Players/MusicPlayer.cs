using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Utility;

public class MusicPlayer : SingletonBehaviour<MusicPlayer>
{
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioSource musicSource;

    private int nextClipIndex;
    private float musicClipTime;
    private float currentClipLength;
    private AudioClip currentClip;
    [SerializeField] InputAction testSwitchSongAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EaseInSong(musicClips[nextClipIndex], 8f));
    }

    // Update is called once per frame
    void Update()
    {
        musicClipTime -= Time.deltaTime;

        if (musicClipTime <= 0)
        {
            if (nextClipIndex == musicClips.Length)
                nextClipIndex = 0;

            StartCoroutine(EaseInSong(musicClips[nextClipIndex], 8f));
        }

        if (testSwitchSongAction.WasPressedThisFrame())
        {
            if (nextClipIndex == musicClips.Length)
                nextClipIndex = 0;

            StartCoroutine(EaseInSong(musicClips[nextClipIndex], 8f));
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

        while (musicSource.volume < 1)
        {
            musicSource.volume += Time.deltaTime / easeTime;
            
            yield return null;
        }
    }
    public void OnSceneLoad(Scene scene, LoadSceneMode sceneMode)
    {
        if (nextClipIndex == musicClips.Length)
            nextClipIndex = 0;
        if (scene == SceneManager.GetSceneByBuildIndex(0))
            StartCoroutine(EaseInSong(musicClips[nextClipIndex], 8f));
        else if (scene == SceneManager.GetSceneByBuildIndex(1))
            StartCoroutine(EaseInSong(musicClips[nextClipIndex], 8f));
    }

    public override void Instantiate()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        testSwitchSongAction.Enable();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
}

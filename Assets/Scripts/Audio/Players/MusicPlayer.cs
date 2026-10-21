using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicClips;
    private AudioSource musicSource;

    private int nextClipIndex;
    private float musicClipTime;
    private float currentClipLength;
    private AudioClip currentClip;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic(musicClips[nextClipIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        musicClipTime -= Time.deltaTime;

        if (musicClipTime <= 0)
        {
            if (nextClipIndex == musicClips.Length)
            {
                nextClipIndex = 0;
                PlayMusic(musicClips[nextClipIndex]);
            }
            else
            {
                PlayMusic(musicClips[nextClipIndex]);
            }
        }

    }
    private void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        currentClip = clip;

        currentClipLength = clip.length;
        musicClipTime = currentClipLength;

        musicSource.Play();

        nextClipIndex++;
    }
}

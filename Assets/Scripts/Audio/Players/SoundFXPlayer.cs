using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SoundFXPlayer : SingletonBehaviour<SoundFXPlayer>
{
    [SerializeField] public Dictionary<string, AudioClip> soundFXCollection;
    [SerializeField] private AudioSource[] audioSources;
    private AudioClip currentClip;

    private int nextSourceIndex;
    public void PlaySFX(AudioClip clip, Transform sourcePos)
    {
        currentClip = clip;

        if (nextSourceIndex == audioSources.Length)
            nextSourceIndex = 0;

        float pitch = Random.Range(0.94f, 1.06f);

        audioSources[nextSourceIndex].gameObject.transform.position = sourcePos.position;

        audioSources[nextSourceIndex].clip = clip;
        audioSources[nextSourceIndex].pitch = pitch;

        audioSources[nextSourceIndex].Play();
        nextSourceIndex++;
    }

    public override void Instantiate()
    {
    }
}

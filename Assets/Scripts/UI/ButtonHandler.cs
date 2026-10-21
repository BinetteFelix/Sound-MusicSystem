using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private SoundFXPlayer fxPlayer => SoundFXPlayer.Instance;
    public void PlayFX(string clipName)
    {
        fxPlayer.PlaySFX(fxPlayer.soundFXCollection[clipName], transform);
    }
}

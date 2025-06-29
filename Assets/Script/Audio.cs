using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource source;
    public AudioSource sourceBGM;

    public AudioClip clip;

    public void PlayAudioSFX()
    {
        source.PlayOneShot(clip);
    }

    public void PlayBGM()
    {
        sourceBGM.volume = 1;
    }

    public void StopBGM()
    {
        sourceBGM.volume = 0;
    }
}
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    private AudioSource BGM;

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
        BGM.Play();
    }

    public void SetVolume(float volume)
    {
        BGM.volume = volume;
    }

    public void Mute()
    {
        // Stop/Play should be used instead of mute and unmute so that
        // the song starts from the beginning
        BGM.Stop();
    }

    public void Unmute()
    {
        BGM.Play();
    }
}
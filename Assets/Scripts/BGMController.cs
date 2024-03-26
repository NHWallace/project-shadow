using UnityEngine;

public class BGMController : MonoBehaviour
{

    private AudioSource BGM;
    public AudioClip main_menu_bgm;
    public AudioClip game_bgm;

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
        BGM.clip = main_menu_bgm;
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

    public void PlayMainMenuBGM()
    {
        BGM.clip = main_menu_bgm;
    }

    public void PlayGameBGM()
    {
        BGM.clip = game_bgm;
    }
}
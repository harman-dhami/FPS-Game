using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audio;
    AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        StartCoroutine(playSound());
    }

    public void ControlVolume(float volume)
    {
        audio.SetFloat("Volume", volume);
    }

    private IEnumerator playSound()
    {
        backgroundMusic.Play();
        yield return true;
    }
}

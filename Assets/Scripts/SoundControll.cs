using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundControll : MonoBehaviour
{
    public Slider sound;
    public Slider music;
    public AudioMixer musicMixer;
    public AudioMixer soundsMixer;
    public void Start()
    {
        sound.value = PlayerPrefs.GetFloat("CurrentSound");
        music.value = PlayerPrefs.GetFloat("CurrentMusic");
    }
    public void MusicChange(float music)
    {
        PlayerPrefs.SetFloat("CurrentMusic", music);
        musicMixer.SetFloat("musicVolume", music);
    }
    public void SoundChange(float sound)
    {
        PlayerPrefs.SetFloat("CurrentSound", sound);
        soundsMixer.SetFloat("soundsVolume", sound);
    }
}

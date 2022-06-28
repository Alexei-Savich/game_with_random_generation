using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ModeChoose : MonoBehaviour
{
    public GameObject music;
    public GameObject sound;
    public void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        sound = GameObject.FindGameObjectWithTag("Sounds");
    }

    public void MenuScreen()
    {
        SoundManagerScript.PlaySound("menu");
        Destroy(sound);
        Destroy(music);
        SceneManager.LoadScene("MainMenu");
    }
    public void Survival()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Survival");
    }
    public void Normal()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("CharChoose");
    }
    public void Boss()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("CharChooseBoss");
    }
}

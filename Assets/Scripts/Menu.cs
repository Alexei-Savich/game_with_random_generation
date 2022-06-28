using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject sound;
    public GameObject music;
    public void Start()
    {
        sound = GameObject.FindGameObjectWithTag("Sounds");
        music = GameObject.FindGameObjectWithTag("Music");
    }
    // Start is called before the first frame update
    public void Play()
    {

        SceneManager.LoadScene("ModeChoose");
        SoundManagerScript.PlaySound("menu");
    }
    public void Exit()
    {

        Application.Quit();
        SoundManagerScript.PlaySound("menu");
    }
    public void MenuScreen()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SoundManagerScript.PlaySound("menu");
        Destroy(sound);
        Destroy(music);
    }
    public void HowTo()
    {

        SceneManager.LoadScene("HowTo");
        SoundManagerScript.PlaySound("menu");
    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        SoundManagerScript.PlaySound("menu");
    }
    public void Settings()
    {

        SceneManager.LoadScene("Settings");
        SoundManagerScript.PlaySound("menu");
    }
    public void Tutorial()
    {

        SceneManager.LoadScene("TutChoose");
        SoundManagerScript.PlaySound("menu");
    }
}

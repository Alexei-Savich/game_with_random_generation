using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused;
    public bool isWin;
    public GameObject win;
    public GameObject[] activeP;
    public GameObject[] disP;
    void Start()
    {
        isWin = false;
    }
    void Update()
    {
        if (isWin!=false)
        {
            win.SetActive(true);
        }
        else
        {
            win.SetActive(false);
        }
        if (Time.timeSinceLevelLoad<0.1)
        {
            Resume();
        }
    }

    public void Resume()
    {

        gameIsPaused = false;
        for (int i = 0; i < activeP.Length; i++)
        {
            activeP[i].SetActive(false);
        }
            for (int g = 0; g < disP.Length; g++)
            {
                disP[g].SetActive(true);
            }

        Time.timeScale = 1f;
        if (Time.timeSinceLevelLoad > 0.1)
        {
            SoundManagerScript.PlaySound("menu");
        }
    }
    public void PauseGame()
    {

        gameIsPaused = true;
        for (int i = 0; i < activeP.Length; i++)
        {
            activeP[i].SetActive(true);
        }
            for (int g = 0; g < disP.Length; g++)
            {
                disP[g].SetActive(false);
            }
        Time.timeScale = 0f;
        if (Time.timeSinceLevelLoad > 0.1)
        {
            SoundManagerScript.PlaySound("menu");
        }
    }
}

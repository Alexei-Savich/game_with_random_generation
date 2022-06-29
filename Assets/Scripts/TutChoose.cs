using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutChoose : MonoBehaviour
{
    public void Back()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("HowTo");
    }
    public void Normal()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("NormalTut");
    }

    public void Survival()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("Surv");
    }
    public void Boss()
    {
        SoundManagerScript.PlaySound("menu");
        SceneManager.LoadScene("BossTut");
    }
}

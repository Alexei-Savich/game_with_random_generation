using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChChooseNormal : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("ModeChoose");
        SoundManagerScript.PlaySound("menu");

    }
    public void Archer()
    {
        SceneManager.LoadScene("ArNormal");
        SoundManagerScript.PlaySound("menu");

    }
    public void TNT()
    {
        SceneManager.LoadScene("TNTNormal");
        SoundManagerScript.PlaySound("menu");

    }
    public void Melee()
    {
        SceneManager.LoadScene("MeleeNormal");
        SoundManagerScript.PlaySound("menu");

    }
    public void MeleeB()
    {
        SceneManager.LoadScene("MeleeBoss");
        SoundManagerScript.PlaySound("menu");

    }
    public void ArcherB()
    {
        SceneManager.LoadScene("ArBoss");
        SoundManagerScript.PlaySound("menu");

    }
    public void TNTB()
    {
        SceneManager.LoadScene("TNTBoss");
        SoundManagerScript.PlaySound("menu");

    }
    public void RocketNormal()
    {
        SceneManager.LoadScene("RocketNormal");
        SoundManagerScript.PlaySound("menu");

    }
    public void RocketBoss()
    {
        SceneManager.LoadScene("RocketBoss");
        SoundManagerScript.PlaySound("menu");

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

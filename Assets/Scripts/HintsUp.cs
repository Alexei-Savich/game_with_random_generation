using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsUp : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBoost") && time>0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;
        }
        if (other.CompareTag("ShieldBoost") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
        if (other.CompareTag("DecreaseBoost") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
        if (other.CompareTag("PlusHeart") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
        if (other.CompareTag("WeaponSurv") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
        if (other.CompareTag("Finish") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
        if (other.CompareTag("BossEnter") && time > 0.3)
        {
            PlayerPrefs.SetInt("Hints", PlayerPrefs.GetInt("Hints") + 1);
            time = 0;

        }
    }
}

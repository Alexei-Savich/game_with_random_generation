using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutSurv : MonoBehaviour
{
    public GameObject[] hints;
    public int hint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < 0.1)
        {
            PlayerPrefs.SetInt("Hints", 0);
        }
        hint = PlayerPrefs.GetInt("Hints");
        switch(hint){
            case 0:
                hints[0].SetActive(true);
                hints[1].SetActive(true);
                for (int i = 2; i < hints.Length; i++)
                {
                    hints[i].SetActive(false);
                }
                break;
            case 1:
                hints[0].SetActive(false);
                hints[1].SetActive(false);
                for (int i = 2; i < hints.Length; i++)
                {
                    hints[i].SetActive(true);
                }
                break;
        }
    }
}

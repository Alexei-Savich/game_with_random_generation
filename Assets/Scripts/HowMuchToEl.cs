using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowMuchToEl : MonoBehaviour
{
    public float timeSinceUnlocked;
    public Text text;
    public GameObject player;
    CharContr characterControl;
    public float howTokill;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceUnlocked = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        characterControl = player.GetComponent<CharContr>();
        if (characterControl.exp < 2500)
        { 
        howTokill = 25 - (characterControl.exp / 100);
        }
        else
        {
            timeSinceUnlocked += Time.deltaTime;
            howTokill = 0;
            if (timeSinceUnlocked > 5)
            {
                this.gameObject.SetActive(false);
            }
        }
        text.text = howTokill.ToString("0");


    }
}

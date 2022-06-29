using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutNormal : MonoBehaviour
{
    BossFight bossSpawn;
    CharContr exper;
    public GameObject[] hints;
    public int hint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        exper = player.GetComponent<CharContr>();
        bossSpawn = player.GetComponent<BossFight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < 0.1)
        {
            PlayerPrefs.SetInt("Hints", 0);
        }
        hint = PlayerPrefs.GetInt("Hints");
        if (exper.exp >= 2500)
        {
            hints[3].SetActive(true);
        }
        else
        {
            hints[3].SetActive(false);

        }
        if (bossSpawn.isSpawned)
        {
            exper.exp = -999;
            hints[4].SetActive(true);
        }
        else
        {
            hints[4].SetActive(false);
        }
        switch (hint)
        {
            case 0:
                hints[1].SetActive(true);
                hints[2].SetActive(false);
                hints[5].SetActive(false);
                break;
            case 1:
                hints[2].SetActive(true);
                hints[1].SetActive(false);
                hints[5].SetActive(false);


                break;
            case 2:
                hints[1].SetActive(false);
                hints[2].SetActive(false);
                hints[5].SetActive(true);
                break;
        }
    }
}

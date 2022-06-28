using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreNormal : MonoBehaviour
{
    public GameObject player;
    public Text score;
    public float scoreTime;
    CharContr characterControl;
    public float exper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        characterControl = player.GetComponent<CharContr>();
        exper = characterControl.exp;
        scoreTime += Time.deltaTime * 5;
        score.text = (scoreTime+exper).ToString("0");
    }
}

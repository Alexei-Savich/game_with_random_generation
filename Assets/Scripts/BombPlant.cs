using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombPlant : MonoBehaviour
{
    public Slider reloadBar;
    public float slider;
    public float reloadTime;
    public Text reload;
    public float timeBtwSp;
    public float timeBtwB;
    public GameObject bomb;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwB = 10;
        slider = 10;
        reloadTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        reloadBar.value = slider;
        if (reloadTime > 0)
        {
            slider += Time.deltaTime;
            reloadTime -= Time.deltaTime;
        }
        else
        {
            slider = 10;
            reloadTime = 0;
        }
        reload.text = reloadTime.ToString("0");
        timeBtwB += Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Plant()
    {
        
        if (timeBtwB > timeBtwSp)
        {
            slider = 0;
            reloadTime = 10;
            timeBtwB = 0;
            Instantiate(bomb, player.position, Quaternion.identity);
        }

    }
}

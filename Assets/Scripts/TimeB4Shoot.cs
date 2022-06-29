using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeB4Shoot : MonoBehaviour
{
    Shooting reqTime;
    public GameObject joystick;
    public Slider timeB4;
    public float reloadTime;
    public Text reload;
    // Start is called before the first frame update
    void Start()
    {
        reqTime = joystick.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {

        if (reloadTime > 15)
        {
            reloadTime = 15;
        }
        reloadTime = reqTime.timeBtwShoots;
        reload.text = (15-reloadTime).ToString("0");
        timeB4.value = reloadTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float reloadTime;
    public Text reload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
        }
        else
        {
            reloadTime = 0;
        }
        reload.text = reloadTime.ToString("0");
    }
}

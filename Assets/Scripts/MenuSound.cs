using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.time > 0.1)
        {
        }
        i = Random.Range(1, 3);
        switch (i)
        {
            case (1):
                MusicManagerScript.PlaySound("first");
                break;
            case (2):
                MusicManagerScript.PlaySound("second");
                break;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

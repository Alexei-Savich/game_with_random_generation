using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerScript.PlaySound("explosion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

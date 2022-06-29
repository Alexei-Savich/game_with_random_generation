using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, Random.Range(0, 2) * 180));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

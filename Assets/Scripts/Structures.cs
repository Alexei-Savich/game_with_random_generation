using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structures : MonoBehaviour
{
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(Random.Range(transform.position.x, x), Random.Range(transform.position.y, y),0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

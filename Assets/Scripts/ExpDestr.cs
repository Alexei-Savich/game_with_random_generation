using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDestr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
    if (other.CompareTag("Experience"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BigExp"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BossExp"))
        {
            Destroy(other.gameObject);
        }

    }
    

}

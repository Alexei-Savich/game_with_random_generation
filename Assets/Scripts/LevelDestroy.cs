using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroy : MonoBehaviour
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
        if(other.CompareTag( "Player") || other.CompareTag("BossEnter"))
        {
        }
        else
        {
            Destroy(other.gameObject, 1f);
        }
    }
}

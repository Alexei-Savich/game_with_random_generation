using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvObst : MonoBehaviour
{
    public SpriteRenderer texture;
    public GameObject player;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        if(Vector2.Distance(transform.position, player.transform.position) > 1.3f)
        {
            texture.enabled = false;
        }
        else
        {
            texture.enabled = true;
        }
        if (Vector2.Distance(transform.position, boss.transform.position) > 4)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}

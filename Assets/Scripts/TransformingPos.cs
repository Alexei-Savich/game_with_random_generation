using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingPos : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject teleportPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.SetPositionAndRotation(new Vector3(teleportPoint.transform.position.x + x, teleportPoint.transform.position.y +y, 0), Quaternion.identity);
        }
    }
}

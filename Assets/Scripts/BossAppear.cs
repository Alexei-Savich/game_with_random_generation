using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    public bool isSp;
    public GameObject[] boss;
    // Start is called before the first frame update
    void Start()
    {
        isSp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isSp!=true)
        {
            Instantiate(boss[Random.Range(0, boss.Length)], new Vector3(transform.position.x, transform.position.y - 6), Quaternion.identity);
            isSp = true;
            Destroy(gameObject);
        }
    }
}

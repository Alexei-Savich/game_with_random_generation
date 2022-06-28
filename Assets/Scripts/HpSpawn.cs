using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSpawn : MonoBehaviour
{
    public int health = 2;
    public float timeBtwDamage;
    public float invTime = 1 / 10;
    public int amountHpSpawned=0;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public GameObject hp;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwDamage += Time.deltaTime;
        if (health <= 0)
        {
            Dest();
        }
        if (timeBtwSpawn <= 0)
        {
            Instantiate(hp, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            amountHpSpawned = amountHpSpawned + 1;
        }
        else
        {
            if (amountHpSpawned >= 3)
            {
                DestroySp();
            }
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    void DestroySp()
    {
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            Dest();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage > invTime)
        {
            health = health - 1;
            timeBtwDamage = 0;
        }
    }
    void Dest()
    {
        Destroy(this.gameObject);
    }
}

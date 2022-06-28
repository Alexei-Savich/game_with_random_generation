using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject expr;
    public int health = 5;
    public float timeBtwDamage;
    public float invTime = 1 / 10;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public GameObject enemy;
    public float experinceOfThePl;
    CharContr characterContr;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwSpawn = startTimeBtwSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        characterContr = player.GetComponent<CharContr>();
        experinceOfThePl = characterContr.exp;
        if (experinceOfThePl <2500)
        {
            health = 5;
        }
        
        timeBtwDamage += Time.deltaTime;
        if (health <= 0)
        {
            Dest();
        }
        if (timeBtwSpawn <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            startTimeBtwSpawn = 0.9f * startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            if (experinceOfThePl > 5000)
            {
                Dest();
            }
        }
    }
    void Dest()
    {
        Destroy(this.gameObject);
        Instantiate(expr, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage > invTime)
        {
            health = health - 1;
            timeBtwDamage = 0;
        }
        if (other.CompareTag("AttackCollider") && timeBtwDamage > invTime)
        {
            health = health - 1;
            timeBtwDamage = 0;
        }
    }
}

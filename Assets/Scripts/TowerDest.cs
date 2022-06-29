using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDest : MonoBehaviour
{
    public float timeBtwDamage;
    public int health = 5;
    public GameObject destTower;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwDamage += Time.deltaTime;
        if (health <= 0)
        {
            Instantiate(destTower, transform.position, Quaternion.Euler(0, 0, Random.Range(0,4)*90));
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage>0.1)
        {
            health = health - 1;
            timeBtwDamage = 0;
        }
        if (other.CompareTag("AttackCollider"))
        {
            health = health - 2;
            timeBtwDamage = 0;
        }

    }
    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Explosion") && timeBtwDamage >0.1)
        {
            health = 0;
            timeBtwDamage = 0;
        }
    }
}

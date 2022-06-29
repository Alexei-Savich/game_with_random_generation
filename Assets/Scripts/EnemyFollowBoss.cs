using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBoss : MonoBehaviour
{
    public GameObject effects;
    public int health = 2;
    public float timeBtwDamage;
    public float invTime = 1 / 10;
    private float speed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwDamage += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (health <= 0)
        {
            Dest();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            SoundManagerScript.PlaySound("hit");
            Dest();
        }
        if (other.CompareTag("AttackCollider"))
        {
            SoundManagerScript.PlaySound("hit");
            Dest();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage > invTime)
        {
            SoundManagerScript.PlaySound("hit");
            health = health - 1;
            timeBtwDamage = 0;
        }
        if (other.CompareTag("AttackCollider"))
        {
            SoundManagerScript.PlaySound("hit");
            Dest();
        }
    }
    void Dest()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

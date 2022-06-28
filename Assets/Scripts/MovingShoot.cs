using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShoot : MonoBehaviour
{
    public GameObject effects;
    public int health;
    public float timeBtwDamage;
    public float invTime = 1 / 10;
    Random rand = new Random();
    public Vector2 pos;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public GameObject experience;
    public float speed;
    public GameObject projectile;
    public float range;
    public float goDist;
    public float backDist;
    public Transform player;
    public float timeBtwShoot;
    public float startTimeBtwShoot;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwDamage += Time.deltaTime;
        if (health <= 0)
        {
            Dest();
        }
        if (Vector2.Distance(transform.position, player.position)<=range)
        { if (Vector2.Distance(transform.position, player.position) > backDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else {
                if ((Vector2.Distance(transform.position, player.position) > backDist - 1)&& (Vector2.Distance(transform.position, player.position) < backDist))
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, 0 * Time.deltaTime);
                }
            }
            {
                if((Vector2.Distance(transform.position, player.position) < backDist-1))
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }
            }

        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pos) < 0.2f)
            {
                pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
        }
        if (timeBtwShoot <= 0 && Vector2.Distance(transform.position, player.position) <= range)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoot = startTimeBtwShoot;
        }
        else
        { 
            timeBtwShoot -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {

            Dest();
            SoundManagerScript.PlaySound("hit");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage > invTime)
        {

            health = health - 1;
            timeBtwDamage = 0;
            SoundManagerScript.PlaySound("hit");
        }
        if (other.CompareTag("AttackCollider"))
        {

            health = health - 1;
            timeBtwDamage = 0;
            SoundManagerScript.PlaySound("hit");
        }
    }
    void Dest()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
        Instantiate(experience, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

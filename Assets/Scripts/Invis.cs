using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invis : MonoBehaviour
{
    public GameObject effects;
    public GameObject experience;
    public int health = 2;
    public float timeBtwDamage;
    public float invTimes = 1 / 10;
    public float invTime;
    private float stopDist;
    private float speed;
    private Transform target;
    public SpriteRenderer texture;
    // Start is called before the first frame update
    void Start()
    {
        invTime = Random.Range(0, 10);

        stopDist = 30;
        speed = Random.Range(3f, 4f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwDamage += Time.deltaTime;

        invTime += Time.deltaTime;
        if (invTime>10)
        {
            invTime = 0;
            texture.enabled = false;
        }
        if (invTime > 2 && texture.enabled != true)
        {
            invTime = 0;
            texture.enabled = true;
        }
        if (Vector2.Distance(transform.position, target.position) <= stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            Dest();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            Dest();
        }
        if (other.CompareTag("AttackCollider"))
        {
            Dest();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage > invTimes)
        {
            health = health - 1;
            timeBtwDamage = 0;
        }
    }
    void Dest()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
        Instantiate(experience, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

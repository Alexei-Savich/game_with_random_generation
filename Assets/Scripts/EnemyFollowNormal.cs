using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollowNormal : MonoBehaviour
{
    public GameObject effects;
    public int health = 2;
    public float timeBtwDamage;
    public float invTime = 1 / 10;
    Random rand = new Random();
    private float stopDist;
    private float speed;
    private Transform target;
    public GameObject experience;
    public Vector2 pos;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        stopDist = Random.Range(6f, 9f);
        speed = Random.Range(3f, 4f);
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwDamage += Time.deltaTime;
        if (Vector2.Distance(transform.position, target.position) <= stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pos) < 0.2f)
            {
                pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
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
            SoundManagerScript.PlaySound("hit");
        }
        if (other.CompareTag("AttackCollider"))
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

            Dest();
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

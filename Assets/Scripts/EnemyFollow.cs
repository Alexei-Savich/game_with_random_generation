using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public GameObject effects;
    public int health = 2;
    public float timeBtwDamage;
    public float invTime = 1/10;

    public GameObject experience;
    Random rand = new Random();
    private float stopDist;
    private float speed;
    private Transform target;

    public Vector2 pos;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        stopDist = Random.Range(5f, 8f);
        speed = Random.Range(2f, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwDamage += Time.deltaTime;
        if (Vector2.Distance(transform.position, target.position) <= stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else
        {
            
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, pos) < 0.2f)
            {
                pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
        }
        if (health <= 0)
        {
            Dest();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
                if (other.CompareTag("FriendlyProjectile") && timeBtwDamage>invTime)
        {
            SoundManagerScript.PlaySound("hit");
            health = health - 2;
            timeBtwDamage = 0;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion")){
            Dest();
        }
        if (other.CompareTag("AttackCollider"))
        {
            Dest();
        }

    }
    void Dest()
    {
        Instantiate(effects, transform.position, Quaternion.identity);
        Instantiate(experience, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

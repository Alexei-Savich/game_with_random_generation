using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject effect;
    public float lifetime;
    public Vector2 dist;
    public float speed;
    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dist = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        target = new Vector2(transform.position.x+dist.x, transform.position.y+dist.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (lifetime > 5)
        {
            DestroyPr();
        }

    }
    void DestroyPr()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyPr();
        }
        if (other.CompareTag("Obstage"))
        {
            DestroyPr();
        }

    }

}

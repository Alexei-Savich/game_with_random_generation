using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInv : MonoBehaviour
{
    public float miX;
    public float maX;
    public float miY;
    public float maY;
    public GameObject invObst;
    public SpriteRenderer texture;
    public Vector2 pos;
    public bool isAttackingNow;
    public float attackTime;
    public float waitTime;
    public GameObject inv;
    public int attack;
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        texture.enabled = true;
        isAttackingNow = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;
        attackTime += Time.deltaTime;
        waitTime += Time.deltaTime;
        if (waitTime > 3 && isAttackingNow != true)
        {
            isAttackingNow = true;
            attack = Random.Range(1,4);
            attackTime = 0;
        }
        if (attack != 2 && attack != 3 && attackTime <= 15 && waitTime > 3)
        {
            texture.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, pos, speed *1.3f * Time.deltaTime);
        }
        else
        {
            if (attack != 2 && attack != 3 && attackTime > 15)
            {
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                texture.enabled = true;
                attack = 0;
            }
        }
        if (attack >= 2 && attack <= 2 && attackTime <= 4 && waitTime > 3)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 7)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if ((Vector2.Distance(transform.position, player.transform.position) > 7 - 1) && (Vector2.Distance(transform.position, player.transform.position) < 7))
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0 * Time.deltaTime);
                }
            }

            if ((Vector2.Distance(transform.position, player.transform.position) < 7 - 1))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }

        else
        {
            if (attack != 1 && attack != 3 && attackTime > 4)
            {
                for (int i = 1; i < 5; i++)
                {
                    Instantiate(inv, transform.position, Quaternion.identity);
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                texture.enabled = true;
                attack = 0;
            }
        }
        if (attack != 2 && attack != 1 && attackTime <= 4 && waitTime > 3)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 7)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if ((Vector2.Distance(transform.position, player.transform.position) > 7 - 1) && (Vector2.Distance(transform.position, player.transform.position) < 7))
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0 * Time.deltaTime);
                }
            }

            if ((Vector2.Distance(transform.position, player.transform.position) < 7 - 1))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }
        }
        else
        {
            if (attack != 2 && attack != 1 && attackTime > 4)
            {
                for (int i = 1; i < 8; i++)
                {
                    Instantiate(invObst, new Vector2(Random.Range(miX, maX), Random.Range(miY, maY)), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                texture.enabled = true;
                attack = 0;
            }
        }
    }
}


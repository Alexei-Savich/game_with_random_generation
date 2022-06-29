using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject turret;
    public float miX;
    public float maX;
    public float miY;
    public float maY;
    public GameObject projectile;
    public float timeBtwShoot;
    public Vector2 pos;
    public bool isAttackingNow;
    public float attackTime;
    public float waitTime;
    public GameObject shoot;
    public int attack;
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShoot = 0;
        isAttackingNow = false;
        player = GameObject.FindGameObjectWithTag("Player");
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
        waitTime += Time.deltaTime;
        if (waitTime > 3 && isAttackingNow != true)
        {
            isAttackingNow = true;
            attack = Random.Range(1, 4);
            attackTime = 0;

        }
        if (attack != 2 && attack != 3 && attackTime <= 15 && waitTime > 3)
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
            if (timeBtwShoot <= 0 )
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShoot = 0.3f;
            }
            else
            {
                timeBtwShoot -= Time.deltaTime;
            }

        }
        else
        {
            if (attack != 2 && attack != 3 && attackTime > 15)
            {
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                attack = 0;
            }
        }
        if (attack >= 2 && attack <= 2 && attackTime <= 6 && waitTime > 3)
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
            if (attack != 1 && attack != 3 && attackTime > 6)
            {
                for (int i = 1; i < 5; i++)
                {
                    Instantiate(shoot, transform.position, Quaternion.identity);
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                attack = 0;
            }
        }
        if (attack >= 3 && attack <= 3 && attackTime <= 6 && waitTime > 3)
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
            if (attack != 1 && attack != 2 && attackTime > 6)
            {
                for (int i = 1; i < 4; i++)
                {
                    Instantiate(turret, new Vector2(Random.Range(miX, maX), Random.Range(miY, maY)), Quaternion.identity);
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                attack = 0;
            }
        }
    }
}

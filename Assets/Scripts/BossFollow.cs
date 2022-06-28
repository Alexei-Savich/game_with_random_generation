using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public float miX;
    public float maX;
    public float miY;
    public float maY;
    public GameObject spike;
    public float dashTime;
    public float chargeTime;
    public Vector2 pos;
    public bool isAttackingNow;
    public float attackTime;
    public float waitTime;
    public GameObject follow;
    public int attack;
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        dashTime = 0;
        chargeTime = 0;
        isAttackingNow = false;
        player = GameObject.FindGameObjectWithTag("Player");
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dashTime += Time.deltaTime;
        chargeTime += Time.deltaTime;
        attackTime += Time.deltaTime;
        waitTime += Time.deltaTime;
        if (waitTime > 3 && isAttackingNow != true)
        {
            isAttackingNow = true;
            attack = Random.Range(1, 4);
            attackTime = 0;
            chargeTime = 0;
            dashTime = 0;
        }
        if (attack != 2 && attack != 3 && attackTime <= 20 && waitTime > 3)
        {
            if (chargeTime <= 0.1)
            {
               pos = player.transform.position;
            }
            else
            {
                
                transform.position = Vector2.MoveTowards(transform.position, pos, speed * 3f * Time.deltaTime);
                if(dashTime>1.5f)
                {
                    dashTime = 0;
                    chargeTime = 0;
                }
            }
        }
        else
        {
            if (attack != 2 && attack != 3 && attackTime > 20)
            {
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
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
                for (int i = 1; i <= 4; i++)
                {
                    Instantiate(follow, transform.position, Quaternion.identity);
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                attack = 0;
            }
        }
        if (attack >= 3 && attack <= 3 && attackTime <= 4 && waitTime > 3)
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
            if (attack != 1 && attack != 2 && attackTime > 4)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Instantiate(spike, new Vector2(Random.Range(miX, maX), Random.Range(miY, maY)), Quaternion.identity);
                }
                isAttackingNow = false;
                attackTime = 0;
                waitTime = 0;
                attack = 0;
            }
        }
    }
}

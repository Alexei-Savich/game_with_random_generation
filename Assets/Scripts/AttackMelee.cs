using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : MonoBehaviour
{
    public float angle;
    public float timeBtwAttacks;
    public Joystick js;
    public Vector2 pos;
    public GameObject colliderAt;
    public GameObject player;
    public float attackTime;
    public Animator attack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (js.Horizontal > 0 && js.Vertical > 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Acos(js.Direction.normalized.x);
        }
        if (js.Horizontal > 0 && js.Vertical < 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Asin(js.Direction.normalized.y);
        }
        if (js.Horizontal < 0 && js.Vertical > 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Acos(js.Direction.normalized.x);
        }
        if (js.Vertical < 0 && js.Vertical < 0)
        {
            angle = Mathf.Rad2Deg * -Mathf.Acos(js.Direction.normalized.x);
        }
        timeBtwAttacks += Time.deltaTime;
        attackTime += Time.deltaTime;
        if (js.Horizontal != 0 || js.Vertical != 0)
        {
            pos = new Vector2(player.transform.position.x + 1 * Mathf.Cos(Mathf.Deg2Rad * angle), player.transform.position.y + 1 * Mathf.Sin(Mathf.Deg2Rad * angle));

        }
        else
        {
            pos = new Vector2(player.transform.position.x + ((0.5f) * Mathf.Cos(Mathf.Deg2Rad * angle)), player.transform.position.y + ((0.5f) * Mathf.Sin(Mathf.Deg2Rad * angle)));
        }
              if (Input.GetKeyDown(KeyCode.Space)&&timeBtwAttacks>0.6)
        {
            SoundManagerScript.PlaySound("sword");
            Instantiate(colliderAt, pos, Quaternion.Euler(player.transform.eulerAngles));
            attack.SetBool("IsAttacking", true);
            attackTime = 0;
            timeBtwAttacks = 0;
        }
        if (attackTime >= 0.5)
        {
            attack.SetBool("IsAttacking", false);
        }
        
    }
    public void Attack()
    {
        if (timeBtwAttacks > 0.6)
        {
            SoundManagerScript.PlaySound("sword");
            timeBtwAttacks = 0;
            Instantiate(colliderAt, pos, Quaternion.Euler(player.transform.eulerAngles));
            attack.SetBool("IsAttacking", true);
            attackTime = 0;
        }
    }


}

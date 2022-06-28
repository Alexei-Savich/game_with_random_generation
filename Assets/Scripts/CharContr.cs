using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharContr : MonoBehaviour
{
    public GameObject timePl;
    public bool inBush = false;
    public float timeInbush;
    public float speedConst;
    public float timeBtwExp;
    public float exp;
    public float angle;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 moveVelocity;
    public Joystick js;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inBush != false)
        {
            timeInbush += Time.deltaTime;
        }
        if (timeInbush > 4)
        {
            
            inBush = false;
            gameObject.tag = "Player";
            timePl.gameObject.tag = "Untagged";
        }
        timeBtwExp += Time.deltaTime;
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
        if (js.Horizontal != 0 && js.Vertical != 0)
        {
            speed = (Mathf.Abs(js.Horizontal) + Mathf.Abs(js.Vertical)) * speedConst;
        }
        else
        {
            speed = js.Horizontal * speedConst + js.Vertical * speedConst;
        }
        Vector2 moveInput = new Vector2(js.Horizontal, js.Vertical);
        moveVelocity = moveInput.normalized * speed;


    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, angle));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bush"))
        {
            if (timeInbush<4)
            {
                inBush = true;
                gameObject.tag = "Untagged";
                timePl.gameObject.tag = "Player";
            }
        }
        if (other.CompareTag("Experience"))
        {
            if (timeBtwExp > 0.1)
            {

                timeBtwExp = 0;
                exp = exp + 100;

            }
        }
        if (other.CompareTag("BigExp"))
        {
            if (timeBtwExp > 0.1)
            {

                timeBtwExp = 0;
                exp = exp + 500;
                SoundManagerScript.PlaySound("exp");
            }
           
        }
        if (other.CompareTag("BossExp"))
            {
                if (timeBtwExp > 0.1)
                {

                timeBtwExp = 0;
                    exp = exp + 10000;
                }
            SoundManagerScript.PlaySound("exp");
            }
        if (other.CompareTag("SpeedBoost"))
        {
            if (timeBtwExp > 0.1)
            {

                speedConst = speedConst * 1.3f;
                timeBtwExp = 0;
                SoundManagerScript.PlaySound("bonus");
            }
            
        }
        if (other.CompareTag("IncreaseBoost"))
        {
            if (timeBtwExp > 0.1)
            {

                transform.localScale = new Vector3(transform.lossyScale.x * 2, transform.lossyScale.y * 2, transform.lossyScale.z);
                timeBtwExp = 0;
                SoundManagerScript.PlaySound("bonus");
            }

        }
        if (other.CompareTag("DecreaseBoost"))
        {
            if (timeBtwExp > 0.1)
            {

                transform.localScale = new Vector3(transform.lossyScale.x /2, transform.lossyScale.y /2, transform.lossyScale.z);
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));
                timeBtwExp = 0;
                SoundManagerScript.PlaySound("bonus");
            }

        }
    
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bush"))
        {
            timeInbush = 0;
            gameObject.tag = "Player";
            timePl.gameObject.tag = "Untagged";
            Destroy(other.gameObject);
        }
    }


}
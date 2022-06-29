using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjFly : MonoBehaviour
{
    public GameObject effect;
    public Joystick attack;
    public float slideX;
    public float slideY;
    public Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        slideX = attack.Horizontal*12;
        slideY = attack.Vertical * 12;
    }

    // Update is called once per frame
    void Update()
    {

        pos = new Vector2(transform.position.x+slideX, transform.position.y+slideY);
        transform.position = Vector2.MoveTowards(transform.position, pos, 8f * Time.deltaTime);
        if (Vector2.Distance(transform.position, pos) < 0.1f)
        {
          //  DestroyPr();
        }
    }
    public void DestroyPr()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstage")){
            DestroyPr();
        }
        if (other.CompareTag("Enemy"))
        {
            DestroyPr();
        }
        if (other.CompareTag("StaticEnemy"))
        {
            DestroyPr();
        }
        if (other.CompareTag("CastleTower"))
        {
            DestroyPr();
        }
        if (other.CompareTag("Boss"))
        {
            DestroyPr();
        }

    }

}


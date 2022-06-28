using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    public GameObject bossExp;
    public GameObject win;
    public GameObject slider;
    public Slider bossHp;
    public float timeBtwDamage;
    public int health = 100;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        slider.SetActive(true);
        size = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        slider = GameObject.FindGameObjectWithTag("BossHP");
        bossHp = slider.GetComponent<Slider>();
        bossHp.value = health;
        if (health <= 0)
        {
            Instantiate(bossExp, transform.position, Quaternion.identity);
            Instantiate(win, new Vector2(488,107), Quaternion.identity);
            slider.SetActive(false);
            Destroy(this.gameObject);

        }
        size = transform.lossyScale;
        timeBtwDamage += Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FriendlyProjectile") && timeBtwDamage >0.1)
        {
            SoundManagerScript.PlaySound("hit");
            health = health - 1;
            timeBtwDamage = 0;
            transform.localScale = new Vector3(size.x * 0.99f, size.y * 0.99f, size.z * 1);
        }
        if (other.CompareTag("Explosion"))
        {
            SoundManagerScript.PlaySound("hit");
            health = health - 10;
            timeBtwDamage = 0;
            transform.localScale = new Vector3(size.x * 0.9f, size.y * 0.9f, size.z * 1);
        }
        if (other.CompareTag("AttackCollider"))
        {
            SoundManagerScript.PlaySound("hit");
            health = health - 3;
            timeBtwDamage = 0;
            transform.localScale = new Vector3(size.x * 0.97f, size.y * 0.97f, size.z * 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSurv : MonoBehaviour
{
    public int i;
    public Slider slider;
    public GameObject frPr;
    public float timeBtwShoots;
    public GameObject text;
    public Text numOfAmmo;
    public Joystick whereToshoot;
    public int ammo=0;
    public float timeBtwAmmo;
    public GameObject player;
    public GameObject weapon;
    public bool isActive=false;
    // Start is called before the first frame update
    void Start()
    {
        
            timeBtwShoots = 0;
            player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = ammo;
        if (ammo > 20)
        {
            ammo = 20;
        }
        if (whereToshoot.Horizontal != 0 && timeBtwShoots > 0.5 && ammo>0|| whereToshoot.Vertical != 0 && timeBtwShoots > 0.5 && ammo>0)
        {
            SoundManagerScript.PlaySound("shoot");
            ammo = ammo - 1;
            Instantiate(frPr, player.transform.position, Quaternion.identity);
            timeBtwShoots = 0;
        }

        if (timeBtwShoots > 0.5)
        {
        }
        else
        {
            timeBtwShoots += Time.deltaTime;
        }
        if (isActive != true)
        {
            text.SetActive(false);
            ammo = 0;
            weapon.SetActive(false);
        }
        timeBtwAmmo += Time.deltaTime;
        numOfAmmo.text = ammo.ToString();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WeaponSurv")) 
        {
            SoundManagerScript.PlaySound("inventory");
            isActive = true;
            text.SetActive(true);
            weapon.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ammo")&&timeBtwAmmo>0.1)
        {
            i = Random.Range(1, 3);
            if (i == 1)
            {
                SoundManagerScript.PlaySound("collect1");
            }
            if (i == 2)
            {
                SoundManagerScript.PlaySound("collect2");
            }
            timeBtwAmmo = 0;
            ammo = ammo + 1;
            Destroy(other.gameObject);
        }
    }
}

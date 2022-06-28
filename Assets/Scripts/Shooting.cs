using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject timePl;
    public Joystick attack;
    public GameObject downCentre;
    public Transform player;
    public float shootIsAllowed = 2;
    public float timeBtwShoots;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (attack.Horizontal != 0 && timeBtwShoots > shootIsAllowed || attack.Vertical != 0 && timeBtwShoots>shootIsAllowed)
        {

            timePl.tag = "Untagged";
            player.tag = "Player";
            Instantiate(downCentre, player.transform.position, Quaternion.identity);
            timeBtwShoots = 0;
            SoundManagerScript.PlaySound("shoot");
        }

        if (timeBtwShoots > shootIsAllowed)
        {
        }else
        {
            timeBtwShoots += Time.deltaTime;
        }
    }

}

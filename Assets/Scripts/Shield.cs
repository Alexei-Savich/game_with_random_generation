using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int health=3;
    public float timeBtwDamage;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        timeBtwDamage += Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        transform.SetPositionAndRotation(player.transform.position, Quaternion.identity);
    }
    public void OnTriggerEnter2D(Collider2D other)
      { 
      if (other.CompareTag("Projectile"))
      {
            Destroy(other.gameObject);
          timeBtwDamage = 0;
          health = health - 1; 
      }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject levelDestroy;
    public GameObject slider;
    public bool bossIsAlive;
    public GameObject bossArena;
    public float timeSinceUnlock;
    public GameObject player;
    public CharContr character;
    public GameObject bossDung;
    public float bossSpawn;
    public bool isSpawned;
    // Start is called before the first frame update
    void Start()
    {
        bossIsAlive = false;
        character = player.GetComponent<CharContr>();
        timeSinceUnlock = 0;
        isSpawned = false;
        bossSpawn = Random.Range(0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossIsAlive != true)
        {
            slider.SetActive(false);
        }
        bossArena = GameObject.FindGameObjectWithTag("BossDung");
        if (character.exp >= 2000)
        {
            timeSinceUnlock += Time.deltaTime;
        }

        if (timeSinceUnlock > bossSpawn && isSpawned != true)
        {
            isSpawned = true;
            Instantiate(bossDung, new Vector2(0, 0), Quaternion.identity);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BossEnter"))
        {
            Instantiate(levelDestroy, new Vector2(0, 0), Quaternion.identity);
            transform.position = bossArena.transform.position;
        }
        if (other.CompareTag("BossSpawn"))
        {
            slider.SetActive(true);
            bossIsAlive = true;
        }
    }

}

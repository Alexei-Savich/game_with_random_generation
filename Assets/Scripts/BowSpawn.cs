using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSpawn : MonoBehaviour
{
    public bool bowIsSpawned;
    public GameObject ammo;
    public float spawnTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public GameObject bow;
    public float timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        bowIsSpawned = false;
        timeSpawn = Random.Range(0, 60);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (Time.timeSinceLevelLoad > timeSpawn && bowIsSpawned!=true)
        {
            Instantiate(bow, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            timeSpawn = Random.Range(0, 60);
            spawnTime = 0;
            bowIsSpawned = true;
        }
        if (spawnTime > timeSpawn)
        {
            spawnTime = 0;
            for (int i = 0; i < Random.Range(0,15); i++)
            {
                Instantiate(ammo, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            }
            timeSpawn = Random.Range(0, 60);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expl : MonoBehaviour
{
    public GameObject explosion;
    public float timeBeforeExpl = 2;
    public float timeSinceSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn > timeBeforeExpl)
        {
            DestroyB();
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
    public void DestroyB()
    {
        Destroy(gameObject);
    }
}

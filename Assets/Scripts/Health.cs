using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour

{
    PauseMenu pause;
    public GameObject menu;
    public GameObject[] act;
    public GameObject[] dis;
    private const int maxHearts = 5;
    private float noHp = 0.1f;
    private float timeBtwHp;
    public GameObject hp;

    public GameObject gameOver;
    private float invHp=1;
    private float timeBtwHits;
    private float invTime = 5;
    private float timeSinceSpawn;
    public int health;
    public int numbOfHp;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        pause = menu.GetComponent<PauseMenu>();
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameOver.SetActive(true);
            DestroyPl();
            Time.timeScale = 0;
        }
        else gameOver.SetActive(false);
        timeBtwHp += Time.deltaTime;
        timeBtwHits += Time.deltaTime;
        timeSinceSpawn += Time.deltaTime;
        if (health > numbOfHp)
        {
            health = numbOfHp;
        }
        if (numbOfHp > maxHearts)
        {
            numbOfHp = maxHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numbOfHp)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            minusHp();
            minusHp();
            minusHp();
            minusHp();
            minusHp();
        }
        if (other.CompareTag("Enemy") && timeSinceSpawn > invTime && timeBtwHits>invHp)
        {
            minusHp();
            timeBtwHits = 0;

        }
        if (other.CompareTag("Projectile") && timeSinceSpawn > invTime && timeBtwHits > invHp)
        {
            minusHp();
            timeBtwHits = 0;

            
        }if (other.CompareTag("PlusHealth") && timeBtwHp > noHp) { 
                health = health + 1;
            timeBtwHp = 0;
            }
        if (other.CompareTag("PlusHeart") && timeBtwHp > noHp)
        {
            numbOfHp = numbOfHp + 1;
            timeBtwHp = 0;
        }
        if (other.CompareTag("Finish"))
        {
            pause.isWin = true;
            pause.PauseGame();
            for (int i = 0; i < act.Length; i++)
            {
                act[i].SetActive(true);
            }
            for (int g = 0; g < dis.Length; g++)
            {
                dis[g].SetActive(false);
            }
        }


    }

    public void DestroyPl()
    {
        pause.PauseGame();
        for (int i = 0; i < act.Length; i++)
        {
            act[i].SetActive(true);
        }
        for (int g = 0; g < dis.Length; g++)
        {
            dis[g].SetActive(false);
        }
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
    public void minusHp()
    {
        SoundManagerScript.PlaySound("hit");
        health = health - 1;
    }
    public void plusHp()
    {
        health = health + 1;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Boss")&&timeBtwHits>1.5)
        {
            health = health - 1;
            timeBtwHits = 0;
        }

    }
}

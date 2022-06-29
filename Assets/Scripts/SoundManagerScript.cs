using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip sword, bonus, exp, explosion, hit, shoot, inventory, menu, collect1, collect2, first, second;
    static AudioSource source;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        sword = Resources.Load<AudioClip>("sword");
        bonus = Resources.Load<AudioClip>("bonus");
        exp = Resources.Load<AudioClip>("exp");
        explosion = Resources.Load<AudioClip>("explosion");
        hit = Resources.Load<AudioClip>("hit");
        shoot = Resources.Load<AudioClip>("shoot");
        inventory = Resources.Load<AudioClip>("inventory");
        menu = Resources.Load<AudioClip>("menu");
        collect1 = Resources.Load<AudioClip>("collect1");
        collect2 = Resources.Load<AudioClip>("collect2");
        first = Resources.Load<AudioClip>("first");
        second = Resources.Load<AudioClip>("second");
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hit":
                source.PlayOneShot(hit);
                break;
            case "explosion":
                source.PlayOneShot(explosion);
                break;
            case "exp":
                source.PlayOneShot(exp);
                break;
            case "bonus":
                source.PlayOneShot(bonus);
                break;
            case "sword":
                source.PlayOneShot(sword);
                break;
            case "shoot":
                source.PlayOneShot(shoot);
                break;
            case "menu":
                source.PlayOneShot(menu);
                break;
            case "collect1":
                source.PlayOneShot(collect1);
                break;
            case "collect2":
                source.PlayOneShot(collect2);
                break;
            case "first":
                source.PlayOneShot(first);
                break;
            case "second":
                source.PlayOneShot(second);
                break;
            case "inventory":
                source.PlayOneShot(inventory);
                break;
        }
    }
}

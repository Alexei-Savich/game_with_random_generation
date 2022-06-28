using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public static AudioClip first, second;
    static AudioSource source;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
            case "first":
                source.PlayOneShot(first);
                break;
            case "second":
                source.PlayOneShot(second);
                break;

        }
    }
}

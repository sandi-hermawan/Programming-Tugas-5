using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Bonk, Hit, OnShot, SlingShot;
    static AudioSource audioSrc;

    void Start()
    {
        Bonk = Resources.Load<AudioClip>("bonk");
        Hit = Resources.Load<AudioClip>("hit");
        OnShot = Resources.Load<AudioClip>("onShot");
        SlingShot = Resources.Load<AudioClip>("slingShot");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bonk":
                audioSrc.PlayOneShot(Bonk);
                break;
            case "hit":
                audioSrc.PlayOneShot(Hit);
                break;
            case "onShot":
                audioSrc.PlayOneShot(OnShot);
                break;
            case "slingShot":
                audioSrc.PlayOneShot(SlingShot);
                break;
        }
    }
}

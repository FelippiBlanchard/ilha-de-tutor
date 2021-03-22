using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource clickButtom;
    public AudioSource dieMusic;
    public AudioSource collectCherries;
    public AudioSource congrats;
    public AudioSource start;
    public static AudioController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        backgroundMusic.Play();
    }
    public void songClickButtom()
    {
        clickButtom.Play();
    }
    public void songDieMusic()
    {
        dieMusic.Play();
        backgroundMusic.Stop();
    }
    public void songCollectCherries()
    {
        collectCherries.Play();
    }
    public void songBackgroundMusic()
    {
        backgroundMusic.Play();
        dieMusic.Stop();
    }
    public void songCongrats()
    {
        congrats.Play();
    }
    public void songStart()
    {
        start.Play();
    }

    // Update is called once per frame

}

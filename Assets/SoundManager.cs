using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound;
    public AudioClip buySound;
    public AudioClip typingSound;
    public AudioClip eatSound;
    public AudioClip chatSound;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void playCoinSound()
    {
        AS.loop = false;
        AS.clip = coinSound;
        AS.Play();
    }
    public void playChatSound()
    {
        AS.loop = false;
        AS.clip = chatSound;
        AS.Play();
    }

    public void playTypingSound()
    {
        AS.loop = true;
        AS.clip = typingSound;
        AS.Play();
    }
    public void playEatSound()
    {
        AS.loop = false;
        AS.clip = eatSound;
        AS.Play();
    }
    public void playBuySound()
    {
        AS.loop = false;
        AS.clip = buySound;
        AS.Play();
    }

}

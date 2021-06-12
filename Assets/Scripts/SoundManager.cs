using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound;
    public AudioClip buySound;
    public AudioClip buySound2;
    public AudioClip typingSound;
    public AudioClip eatSound;
    public AudioClip chatSound;
    public AudioClip miniGameWinSound;
    public AudioClip miniGameLoseSound;
    public AudioClip csGoShootSound;
    public AudioClip csGoDeathSound;
    public AudioClip csGoBGMSound;
    public AudioClip clickSound;
    public AudioClip clickErrorSound;
    public AudioClip openWindowSound;
    public AudioClip closeWindowSound;
    public AudioClip UpgradeSound;

    public AudioSource AS;
    public AudioSource AS2;
    public AudioSource BGM;
    public AudioSource CSGOBGM;
    public AudioSource SleepBGM;
    public AudioSource AS3;
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


    public void playDeathSound(){
        AS3.loop = false;
        AS3.clip = csGoDeathSound;
        AS3.Play();
    }

    public void playShootSound(){
        AS2.loop = false;
        AS2.clip = csGoShootSound;
        AS2.Play();
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
    
    public void PlaySound(AudioClip clip){
        AS.loop = false;
        AS.clip = clip;
        AS.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    public StreamChosenGame SCG;
    // Start is called before the first frame updatep
    public void Skip(){
        if( miniGameState.State == miniGameState.mgState.onGoing){
            FindObjectOfType<SoundManager>().SimsBGM.enabled = false;
            FindObjectOfType<SoundManager>().AmongUsBGM.enabled = false;
            FindObjectOfType<SoundManager>().MCBGM.enabled = false;
            FindObjectOfType<SoundManager>().CSGOBGM.enabled = false;
            FindObjectOfType<SoundManager>().BGM.Play();
            miniGameState.State = miniGameState.mgState.stopped;
        }

        }
 }


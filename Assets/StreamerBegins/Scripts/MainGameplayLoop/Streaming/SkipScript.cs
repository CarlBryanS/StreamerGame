using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    public StreamChosenGame SCG;
    // Start is called before the first frame updatep
    public SoundManager SoundManager;
        void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

    public void Skip(){
        if( miniGameState.State == miniGameState.mgState.onGoing){
            SoundManager.SimsBGM.enabled = false;
            SoundManager.AmongUsBGM.enabled = false;
            SoundManager.MCBGM.enabled = false;
            SoundManager.CSGOBGM.enabled = false;
            SoundManager.BGM.Play();
            miniGameState.State = miniGameState.mgState.stopped;
        }

        }
 }


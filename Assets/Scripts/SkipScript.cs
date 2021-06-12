using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    public StreamChosenGame SCG;
    // Start is called before the first frame updatep
    public void Skip(){
        if( miniGameState.State == miniGameState.mgState.onGoing){
            miniGameState.State = miniGameState.mgState.stopped;
        }

            }
 }


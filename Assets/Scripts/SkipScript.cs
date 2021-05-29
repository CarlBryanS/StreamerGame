using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    public StreamChosenGame SCG;
    // Start is called before the first frame updatep
    public void Skip(){
            SCG.streamDurationBar = 1f;
            SCG.streamDurationTimer = 1f;
            }
 }


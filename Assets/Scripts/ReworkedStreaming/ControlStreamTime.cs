using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlStreamTime : MonoBehaviour
{
    public TMP_Text TimeIndicator;
    public DurationControl DC;
    public static int StreamTime;
    
    void Start(){
        StreamTime = 1;
    }

    public void MinusHour(){
        StreamTime -= 1;
        if(StreamTime > 24){
            StreamTime = 24;
        }

        if(StreamTime<=1){
            StreamTime = 1;
        }


        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }
    public void AddHour(){
        if(DecreaseIndicator.statRanOut == false){
            StreamTime += 1;
            if(StreamTime > 24){
                StreamTime = 24;
            }

            if(StreamTime<=1){
                StreamTime = 1;
            }
        }
        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }

    public void ResetTimeVisual(){
        //DecreaseIndicator.statRanOut = false;
        StreamTime =1;
        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }
}

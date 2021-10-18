using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlStreamTime : MonoBehaviour
{
    public TMP_Text TimeIndicator;
    public DurationControl DC;
    public GameObject StreamButton;
    public static int StreamTime;
    
    void Start(){
        StreamTime = 0;
    }

    public void MinusHour(){
        StreamButton.SetActive(true);
        StreamTime -= 1;
        if(StreamTime > 24){
            StreamTime = 24;       
        }

        if(StreamTime<=0){
            StreamTime = 0;
            StreamButton.SetActive(false);
        }


        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }
    public void AddHour(){
        if(DecreaseIndicator.statRanOut == false){
            StreamTime += 1;
            StreamButton.SetActive(true);
            if(StreamTime > 24){
                StreamTime = 24;
            }

            if(StreamTime<=0){
                StreamTime = 0;
                StreamButton.SetActive(false);
            }
        }
        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }

    public void ResetTimeVisual(){
        //DecreaseIndicator.statRanOut = false;
        StreamTime =0;
        DC.getTargetValues();
        TimeIndicator.SetText(StreamTime.ToString());
    }
}

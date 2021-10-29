using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UpgradeBuildTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TimerScript timerScript;
    public int TimerNeeded;
    int hourNeeded;
    int minutes;

    int Timer;
    public int Increment;
    public UnityEvent BuildComplete;

    public void StreamUpdateTimerText(){
        if(this.gameObject.activeSelf){
            hourNeeded -= ControlStreamTime.StreamTime;
            timerText.SetText(hourNeeded.ToString() + ":" + "00");
            if(hourNeeded <= 0){
                this.gameObject.SetActive(false);
            }
        }

    }
    public void WorkUpdateTimerText(int Hours){
        if(this.gameObject.activeSelf){
        hourNeeded -= Hours;
        timerText.SetText(hourNeeded.ToString() + " : " + "00");
        if(hourNeeded <= 0){
            this.gameObject.SetActive(false);
            UpTheUpgradeTimer();
        }
        }
    }
    public void UpdateTimer(){
        //Timer += 1;
       // if(TimerNeeded == Timer){
       //     this.gameObject.SetActive(false);
       // }
    }

    private void UpTheUpgradeTimer() {
        TimerNeeded +=Increment;
        BuildComplete.Invoke();
    }

    public void BuildTimer(){
        hourNeeded = returnHour(TimerNeeded);
        timerText.SetText(hourNeeded.ToString() + " : " + "00");
    }

    public int returnHour(int timerNeeded){
        return timerNeeded * 24;
    }
}

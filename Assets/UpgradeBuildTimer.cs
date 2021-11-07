using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UpgradeBuildTimer : MonoBehaviour
{
    WORLDPARAMETERS WP;
    public TextMeshProUGUI timerText;
    public TimerScript timerScript;
    public int TimerNeeded;
    int hourNeeded;
    int minutes;

    int Timer;
    public int Increment;
    public UnityEvent BuildComplete;

    int oldDay;
    int currentDay;
    private void Awake() {
    WP = FindObjectOfType<WORLDPARAMETERS>();    
    }

    void Update(){

    }
    public void StreamUpdateTimerText(){
        if(this.gameObject.activeSelf){
            hourNeeded -= ControlStreamTime.StreamTime;
         //   timerText.SetText("Upgrading: "+"\n" +"Hrs: " + hourNeeded.ToString() + " : " + "00");
            timerText.SetText(returnDay(hourNeeded).ToString());
            if(hourNeeded <= 0|| TimerNeeded <=0){
                this.gameObject.SetActive(false);
                UpTheUpgradeTimer();
            }
        }

    }
    public void WorkUpdateTimerText(int Hours){
        if(this.gameObject.activeSelf){
            if(WP.Energy >= PartTimeScript.currentPartTimeEnergyCost && WP.Health >= PartTimeScript.currentPartTimeHealthCost){
                hourNeeded -= Hours;
            // timerText.SetText("Upgrading: "+"\n" +"Hrs: " + hourNeeded.ToString() + " : " + "00");
                timerText.SetText(returnDay(hourNeeded).ToString());
                if(hourNeeded <= 0||TimerNeeded <=0){
                    this.gameObject.SetActive(false);
                    UpTheUpgradeTimer();
                }
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
       // timerText.SetText("Upgrading: "+"\n" +"Days: " + hourNeeded.ToString() + " : " + "00");
        timerText.SetText(TimerNeeded.ToString());
    }

    public int returnHour(int timerNeeded){
        return timerNeeded * 24;
    }
    public int returnDay(int timerNeeded){
        float day = timerNeeded;
        return Mathf.CeilToInt(day / 24);
    }

    public void reduceTimer(){
        if(this.gameObject.activeSelf){
            TimerNeeded-=1;
        }
    }
}

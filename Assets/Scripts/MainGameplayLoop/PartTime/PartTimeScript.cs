using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTimeScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public UISliding UI;
    public TimerScript TS;  
    public SetVisualStats SVS;
   // public float partTimeCost;
    public float partTimeDuration;
    public float ptDurationBar;
   // public int partTimeSalary;
    public bool amIWorking;
    public static bool isWorking;

    bool isEnergyDone;
    bool isHealthDone;
    bool isTimeDone;
    float tempCurrentHour;

void Update(){
        Debug.Log(isWorking);
        Debug.Log(isEnergyDone);
        Debug.Log(isHealthDone);
        Debug.Log(isTimeDone);
        Debug.Log(Mathf.Abs(Mathf.RoundToInt(tempCurrentHour)));
        Debug.Log(Mathf.Abs(Mathf.RoundToInt(TimerScript.currentHour)));
        if(isWorking){
            checkIfWorkEnded();
            if( WP.Energy >= WP.tempEnergy){
                WP.Energy -= Time.unscaledDeltaTime / ptDurationBar;
            }
            else{
                isEnergyDone = true;
            }
 
            if (WP.Health >= WP.tempHealth)
            {  
                WP.Health -= Time.unscaledDeltaTime / ptDurationBar;
            }
            else{
                 isHealthDone = true;
            }

            if(Mathf.Abs(Mathf.RoundToInt(tempCurrentHour)) !=Mathf.Abs(Mathf.RoundToInt(TimerScript.currentHour))){
                TS.TimeStart(partTimeDuration);
            }
            else{
                isTimeDone = true;
            }          
        }
    }


 public void DoJob(string Job)
    {
       switch(Job){
        case "6/12":
            ptDurationBar = 5;
            partTimeDuration = 10;
            WorkPartTime(0.4f, 0.1f, 50, 6);
            break;
        case "comShop":
            ptDurationBar = 5;
            partTimeDuration = 10;
            WorkPartTime(0.1f, 0.05f, 15, 6);
            break;
        case "callCenter":
            ptDurationBar = 5;
            partTimeDuration = 10;
            WorkPartTime(0.1f, 0.4f, 30, 6);
            break;
           default:
            Debug.Log("What Job Is this");
            break; 
       } 
    
     
    }

    void WorkPartTime(float partTimeEnergyCost, float partTimeHealthCost, int partTimeSalary, float jobTime){
        isEnergyDone = false;
        isHealthDone = false;
        isTimeDone = false;
        tempCurrentHour = TS.getNextTime(jobTime);
        WP.tempEnergy = WP.Energy;
        WP.tempHealth = WP.Health;

        //tempMoney = WP.Money;
        if (WP.Energy >= partTimeEnergyCost && WP.Health >= partTimeHealthCost)
            {
                
                WP.tempHealth -= partTimeHealthCost;
                WP.tempEnergy -= partTimeEnergyCost;
                
                WP.Money += partTimeSalary;            
                amIWorking = true;
                UI.ClosePartTimeScreen();
                isWorking = true;
               // WP.ControlStreamUI(false);
            }
    }

    void checkIfWorking()
    {
        if(isEnergyDone&& isHealthDone && isTimeDone){
            amIWorking = false;
            isWorking = false;
        }
    }

    void checkIfWorkEnded()
    {
        /*if (WP.Health <= WP.tempHealth || WP.Energy <= WP.tempEnergy)
        {    
           Debug.Log("work ended");
            SVS.UpdateUI();
            //UI.OpenResultsScreen();
            //PS.Idle();
        }*/
        if(isEnergyDone&& isHealthDone && isTimeDone){
            amIWorking=false;
            isWorking =false;
            WP.Energy = WP.tempEnergy;
            WP.Health = WP.tempHealth;
            Debug.Log("work ended");
            SVS.UpdateUI();
        }
    }

}

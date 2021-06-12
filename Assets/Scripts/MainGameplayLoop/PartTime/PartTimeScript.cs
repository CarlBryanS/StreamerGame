using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image PartTimePage;
    public Sprite PTFirstPage;
    public Sprite PTLastPage;
    public GameObject PTButton;
    public GameObject PTButton2;
    public int currentPage;

    public GameObject firstPage;
    public GameObject secondPage;
    public GameObject warning;
    public GameObject Brendan;

void Start(){
    currentPage =1;
}
void Update(){
        if(isWorking){
            checkIfWorkEnded();
            if(amIWorking && WP.Energy >= WP.tempEnergy){
                WP.Energy -= Time.unscaledDeltaTime / ptDurationBar;
            }
            else{
                isEnergyDone = true;
            }
 
            if (amIWorking && WP.Health >= WP.tempHealth)
            {  
                WP.Health -= Time.unscaledDeltaTime / ptDurationBar;
            }
            else{
                 isHealthDone = true;
            }

            if(amIWorking && Mathf.Abs(Mathf.RoundToInt(tempCurrentHour)) !=Mathf.Abs(Mathf.RoundToInt(TimerScript.currentHour))){
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
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);   
            ptDurationBar = 5;
            partTimeDuration = 10;
            WorkPartTime(0.4f, 0.1f, 50, 6);
            break;
        case "comShop":
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);   
            ptDurationBar = 7;
            partTimeDuration = 10;
            WorkPartTime(0.15f, 0.2f, 15, 1);
            break;
        case "angkas":
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);   
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
                Brendan.SetActive(false);
               // WP.ControlStreamUI(false);
            }
            else{
                if(!warning.activeSelf){  
                    warning.SetActive(true);
                }
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
        if(isEnergyDone&& isHealthDone && isTimeDone){
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().buySound);
            amIWorking=false;
            isWorking =false;
           //WP.Energy = WP.tempEnergy;
           // WP.Health = WP.tempHealth;
            WP.Health = Mathf.Round(WP.tempHealth*100)/100;
            WP.Energy = Mathf.Round(WP.tempEnergy*100)/100;
            Debug.Log("work ended");
            Brendan.SetActive(true);
            SVS.UpdateUI();
            
        }
    }

    public void checkPage(){
        switch(currentPage){
            case 1:
                PTButton.SetActive(true);
                PTButton2.SetActive(false);
                PartTimePage.sprite =PTFirstPage;
                firstPage.SetActive(true);
                secondPage.SetActive(false);
                Debug.Log("first page");
                break;
            case 2: 
                PTButton2.SetActive(true);
                PTButton.SetActive(false);
                PartTimePage.sprite = PTLastPage;
                firstPage.SetActive(false);
                secondPage.SetActive(true);
                Debug.Log("second page");
                break;
            default:
                Debug.Log("where are we");
                break;
        }
    }

    public void changePage(int pageTurn){
        currentPage += pageTurn;
    }

}

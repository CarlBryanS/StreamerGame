using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WORLDPARAMETERS : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text fansText;
    public TMP_Text currentRigText;

    public float Energy;
    public float Health;
    public int Money;
    public int Fans;
    public int Viewers;


    public float tempHealth;
    public float tempEnergy;


    //bills
    public int Electricity;
    public int Water;
    public int Rent;

    //upgrades
    public int viewerCap;
    public int gamingRigStat;
    public int socialMediaStat;
    public float streamTime;
    public static bool amIUIHovered;

    public Sprite[] popularityImages;
     public GameObject[] UIThatNeedsToBeDisabled;
 
    private void Awake()
    {
        viewerCap = 5;
        socialMediaStat = 0;
        Health = 1;
        Energy = 1;
        Money = 1000;
        Fans = 0;
        Viewers = 0;
        Electricity = 0;
        Water = 0;
        Rent = 0;
    }

    private void Update()
    {
       currentRigText.SetText(gamingRigStat.ToString());
       moneyText.SetText(Money.ToString());
       fansText.SetText(Fans.ToString());

       Application.targetFrameRate =-1; 
       QualitySettings.maxQueuedFrames = 3;    
       //QualitySettings.vSyncCount = 0;
    }

    public void AmHoveredYes(){
        amIUIHovered = true;
    }

    public void ControlStreamUI(bool I){
     foreach(GameObject UI in UIThatNeedsToBeDisabled){
                    UI.SetActive(I);
                }
    }
    public void AmHoveredNo(){
        amIUIHovered = false;
    }
}

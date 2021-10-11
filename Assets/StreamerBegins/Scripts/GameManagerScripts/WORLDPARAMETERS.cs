using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WORLDPARAMETERS : MonoBehaviour
{

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
    public GameObject[] TopUI;

    private void Update()
    {
       currentRigText.SetText(gamingRigStat.ToString());

     //  Application.targetFrameRate =-1; 
     //  QualitySettings.maxQueuedFrames = 3;    
       //QualitySettings.vSyncCount = 0;
    }

    public void AmHoveredYes(){
        amIUIHovered = true;
    }

    public void ControlStreamUI(bool I){
        if(SceneManager.GetActiveScene().buildIndex !=3){
             foreach(GameObject UI in UIThatNeedsToBeDisabled){
                    UI.SetActive(I);
                }
        }
        else{
            foreach(GameObject UI in TopUI){
                UI.SetActive(I);
            }
        }

    }
    public void AmHoveredNo(){
        amIUIHovered = false;
    }
}

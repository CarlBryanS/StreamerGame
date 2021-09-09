using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BillsScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public UISliding UI;
    public SetVisualStats SVS;

    public TimerScript TS;

    public TMP_Text Electricity;
    public TMP_Text Water;

    public GameObject ElectricityObj;
    public GameObject WaterObj;

    public int DayCount;
    public int MonthCount;
    public int DayThreshold;
    public int currentMonth;

    public int MonthThreshold;

    public Sprite[] billsSprites;

    Image billsImage;

    bool billsDue;
    bool lost;
 
    public SoundManager SoundManager;
        void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        lost = false;
        currentMonth = 1;
        billsImage = GetComponent<Image>();
        DayCount = 1;
        MonthCount = 1;
    }

    private void Update()
    {
        if(billsDue ==true && miniGameState.State != miniGameState.mgState.onGoing && StreamChosenGame.amIStreaming == false && GetInBed.isAsleep == false && PartTimeScript.isWorking == false && lost == false){
            UI.OpenBillsScreen();
        }
    }
    public void CheckDays()
    {
        DayCount+= 1;
        MonthCount += 1;
        if(MonthCount == MonthThreshold)
        {
            ElectricityObj.transform.localPosition = new Vector2(10.79f, 6.73f);
            WaterObj.transform.localPosition = new Vector2(10.79f, 19.68f);
            billsImage.sprite = billsSprites[0];
            billsDue = true;
            //if(miniGameState.State != miniGameState.mgState.onGoing){
            //UI.OpenBillsScreen();
            //}

        }
        else if (DayCount>= DayThreshold)
        {

            ElectricityObj.transform.localPosition = new Vector2(10.79f, 9.550006f);
            WaterObj.transform.localPosition = new Vector2(10.79f, -3.4f);
            billsImage.sprite = billsSprites[1];
            WP.Electricity = 500*currentMonth;
            WP.Water =500*currentMonth;
            Electricity.SetText(WP.Electricity.ToString());
            Water.SetText(WP.Water.ToString());
            billsDue=true;
            DayCount = 0;
        }
    }

    public void ConfirmBills()
    {
        if (MonthCount >= MonthThreshold && lost == false)
        {
            if(WP.Money >= (WP.Electricity + WP.Water))
            {
                       SoundManager.PlaySound(SoundManager.buySound); 
                HelpScreenScript.TPayBool = true;
                WP.Money -= (WP.Electricity + WP.Water);
                WP.Electricity = 0;
                WP.Water = 0;
                UI.CloseBillsScreen();
                MonthCount = 1;
                currentMonth +=1;
                billsDue = false;
                SVS.UpdateUI();
            }
            else
            {
                lost = true;
                UI.CloseBillsScreen();
                UI.OpenGOScreen();
            }
           
        }
        else
        {
            billsDue = false;
            UI.CloseBillsScreen();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BillsScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public UISliding UI;

    public TimerScript TS;

    public TMP_Text Electricity;
    public TMP_Text Water;

    public GameObject ElectricityObj;
    public GameObject WaterObj;

    public int DayCount;
    public int MonthCount;
    public int DayThreshold;

    public int MonthThreshold;

    public Sprite[] billsSprites;

    Image billsImage;

 
    private void Start()
    {
        billsImage = GetComponent<Image>();
        DayCount = 1;
        MonthCount = 1;
    }

    private void Update()
    {
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
            
            UI.OpenBillsScreen();
        }
        else if (DayCount>= DayThreshold)
        {

            ElectricityObj.transform.localPosition = new Vector2(10.79f, 9.550006f);
            WaterObj.transform.localPosition = new Vector2(10.79f, -3.4f);
            billsImage.sprite = billsSprites[1];
            WP.Electricity += 25;
            WP.Water += 25;
            Electricity.SetText(WP.Electricity.ToString());
            Water.SetText(WP.Water.ToString());
            UI.OpenBillsScreen();
            DayCount = 0;
        }
    }

    public void ConfirmBills()
    {
        if (MonthCount >= MonthThreshold)
        {
            WP.Money -= (WP.Electricity + WP.Water);
            WP.Electricity = 0;
            WP.Water = 0;
            UI.CloseBillsScreen();
            MonthCount = 0;
        }
        else
        {
            UI.CloseBillsScreen();
        }

    }
}

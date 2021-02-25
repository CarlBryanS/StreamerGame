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

    public int DayCount;
    public int MonthCount;
    public int DayThreshold;

    public int MonthThreshold;

 
    private void Start()
    {
        DayCount = 1;
        MonthCount = 1;
    }

    private void Update()
    {
        Debug.Log(DayCount);
        Debug.Log(MonthThreshold);
    }
    public void CheckDays()
    {
        DayCount+= 1;
        MonthCount += 1;
        if (DayCount>= DayThreshold || MonthCount==MonthThreshold)
        {
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
        Debug.Log(MonthCount);
        if (MonthCount >= MonthThreshold)
        {
            Debug.Log("wow");
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

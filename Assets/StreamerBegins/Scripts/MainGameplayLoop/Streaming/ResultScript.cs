using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public TMP_Text MoneyGained;
    public TMP_Text TotalViewers;
    public TMP_Text FansGained;

    public float MoneyGainedValue;
    public float ViewersForTheDay;
    public float FansGainedValue;
    public float DonationsReceived;


    public void ResetResults()
    {
        DonationsReceived = 0;
        MoneyGainedValue = 0;
        ViewersForTheDay = 0;
        FansGainedValue = 0;
    }

    private void Update()
    {
        Display();
    }
    public void Display()
    {
        MoneyGained.SetText(MoneyGainedValue.ToString());
        TotalViewers.SetText(ViewersForTheDay.ToString());
        FansGained.SetText(FansGainedValue.ToString());
    }
}

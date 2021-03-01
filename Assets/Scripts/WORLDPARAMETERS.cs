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


    private void Awake()
    {
        viewerCap = 5;
        socialMediaStat = 0;
        Health = 1;
        Energy = 1;
        Money = 0;
        Fans = 0;
        Viewers = 0;
        Electricity = 0;
        Water = 0;
        Rent = 0;
    }

    private void Update()
    {
        currentRigText.SetText("Current Rig Level: " + gamingRigStat);
       moneyText.SetText(Money.ToString());
       fansText.SetText(Fans.ToString());
    }

}

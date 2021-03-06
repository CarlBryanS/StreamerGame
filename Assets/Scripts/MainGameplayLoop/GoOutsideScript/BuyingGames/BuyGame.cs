﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGame : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public SetVisualStats SVS;

    public GameObject MC;
    public GameObject CSGO;
    public GameObject SIMS4;

    public GameObject[] bgExtras;
    public GameObject owned;
    public GameObject warning;
    public void Buy()
    {
        switch (this.gameObject.name)
        {
            case "BuyMinecraft":
                if (WP.Money >= 1000 && WP.gamingRigStat >=2)
                {
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().buySound2);   
                    HelpScreenScript.TGameStoreBool = true;
                    owned.SetActive(true);
                    WP.Money -= 1000;
                    MC.SetActive(true);
                    for (int i = 0; i < bgExtras.Length; i++)
                    {
                        bgExtras[i].SetActive(false);
                    }
                    SVS.UpdateUI();
                }
                else{
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickErrorSound);  
                    if(!warning.activeSelf){
                    warning.SetActive(true);
                    } 
                }
                break;
            case "BuyCSGO":
                if (WP.Money >= 2500 && WP.gamingRigStat >= 3)
                {
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().buySound2);   
                    HelpScreenScript.TGameStoreBool = true;
                    owned.SetActive(true);
                    WP.Money -= 2500;
                    CSGO.SetActive(true);
                    for (int i = 0; i < bgExtras.Length; i++)
                    {
                        bgExtras[i].SetActive(false);
                    }
                    SVS.UpdateUI();
                }
                 else{
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickErrorSound);   
                    if(!warning.activeSelf){
                    warning.SetActive(true);
                     }
                }
                break;
            case "BuySims4":
                if (WP.Money >= 5000 && WP.gamingRigStat >= 4)
                {
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().buySound2);   
                    HelpScreenScript.TGameStoreBool = true;
                    owned.SetActive(true);
                    SIMS4.SetActive(true);
                    WP.Money -= 5000;
                    for (int i = 0; i < bgExtras.Length; i++)
                    {
                        bgExtras[i].SetActive(false);
                    }
                    SVS.UpdateUI();
                }       
                 else{
                    FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickErrorSound);   
                    if(!warning.activeSelf){
                    warning.SetActive(true);
                     }
                }
                break;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;

    public int addViewCap;
    public int addSMStat;
    public int addRigStat;

    int InternetLevel;
    int RigLevel;
    int SMMLevel;

    public TMP_Text InternetLevelText;
    public TMP_Text RigLevelText;
    public TMP_Text SMMLevelText;

    public PriceManager InternetPM;
    public PriceManager RigPM;
    public PriceManager SocialMediaPM;

    private void Start()
    {
        InternetLevel = 1;
        RigLevel = 1;
        SMMLevel = 1;
    }

    private void Update()
    {
        InternetLevelText.SetText(InternetLevel.ToString());
        RigLevelText.SetText(RigLevel.ToString());
        SMMLevelText.SetText(SMMLevel.ToString());
    }

    public void InternetUpgrade()
    {
        if (WP.Money >= InternetPM.upgradeCost && InternetLevel < 10)
        {
            InternetLevel += 1;
            HelpScreenScript.TInternetBool = true;
            WP.Money -= InternetPM.upgradeCost;
            
            InternetPM.upgradeCost += 25;

            WP.viewerCap += addViewCap;
        }

       
    }

    public void RigUpgrade()
    {
        if (WP.Money >= RigPM.upgradeCost && RigLevel < 10)
        {
            RigLevel += 1;
            HelpScreenScript.TGamingRigBool = true;
            WP.Money -= RigPM.upgradeCost;

            RigPM.upgradeCost += 100;

            WP.gamingRigStat += addRigStat;

        }
        //raise value of gaming rig
    }

    public void SocialMediaUpgrade()
    {
        if (WP.Money >= SocialMediaPM.upgradeCost && SMMLevel < 10)
        {
            SMMLevel += 1;
            HelpScreenScript.TSocialMediaMarketingBool = true;
            WP.Money -= SocialMediaPM.upgradeCost;

            SocialMediaPM.upgradeCost += 50;

            WP.socialMediaStat += addSMStat;
        }
    }
}

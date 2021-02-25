using System.Collections;
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

    public PriceManager InternetPM;
    public PriceManager RigPM;
    public PriceManager SocialMediaPM;

    public void InternetUpgrade()
    {
        if (WP.Money >= InternetPM.upgradeCost)
        {
            WP.Money -= InternetPM.upgradeCost;
            
            InternetPM.upgradeCost *= 5;

            WP.viewerCap += addViewCap;
            Debug.Log("You have upgraded Internet " + WP.viewerCap);
        }

       
    }

    public void RigUpgrade()
    {
        if (WP.Money >= RigPM.upgradeCost)
        {
            WP.Money -= RigPM.upgradeCost;

            RigPM.upgradeCost *= 5;

            WP.gamingRigStat += addRigStat;

            Debug.Log("You have upgraded Rig " + WP.gamingRigStat);
        }
        //raise value of gaming rig
    }

    public void SocialMediaUpgrade()
    {
        if (WP.Money >= SocialMediaPM.upgradeCost)
        {
            WP.Money -= SocialMediaPM.upgradeCost;

            SocialMediaPM.upgradeCost *= 5;

            WP.socialMediaStat += addSMStat;
            Debug.Log("You have upgraded Social Media " + WP.socialMediaStat);
        }
    }
}

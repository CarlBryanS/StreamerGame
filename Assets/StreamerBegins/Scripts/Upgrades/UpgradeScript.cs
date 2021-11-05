using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public SetVisualStats SVS;
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

    public GameObject InternetButton;
    public GameObject RigButton;
    public GameObject SocialMediaButton;
    public GameObject warning;
    public SoundManager SoundManager;

    public GameObject InternetTimer;
    public GameObject RigTimer;
    public GameObject SocialMediaTimer;

    void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

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
            SoundManager.PlaySound(SoundManager.UpgradeSound);  
            HelpScreenScript.TInternetBool = true;
            WP.Money -= InternetPM.upgradeCost; 
            InternetPM.upgradeCost += 25;
            InternetPM.Upgrade();
            SVS.UpdateUI();
            InitiateBuildTimer(InternetButton.GetComponent<Button>(), InternetTimer);
        }
        else{
                if(!warning.activeSelf){
                    warning.SetActive(true);
                }
        }

       
    }
    public void InternetUpgradeEffect()
    {
        
            InternetLevel += 1;
            WP.viewerCap += addViewCap;
            if(InternetLevel > 9){
                InternetButton.SetActive(false);
            }
    }

    public void RigUpgrade()
    {
        if (WP.Money >= RigPM.upgradeCost && RigLevel < 10)
        {
            SoundManager.PlaySound(SoundManager.UpgradeSound);  
            HelpScreenScript.TGamingRigBool = true;
            WP.Money -= RigPM.upgradeCost;
            RigPM.upgradeCost += 100;
            RigPM.Upgrade();
            SVS.UpdateUI();
            InitiateBuildTimer(RigButton.GetComponent<Button>(), RigTimer);
        }
              else{
                if(!warning.activeSelf){
                    warning.SetActive(true);
                }
        }
        //raise value of gaming rig
    }

    public void RigUpgradeEffect(){
            RigLevel += 1;
            WP.gamingRigStat += addRigStat;
            if(RigLevel > 9){
                RigButton.SetActive(false);
            }
    }

    public void SocialMediaUpgrade()
    {
        if (WP.Money >= SocialMediaPM.upgradeCost && SMMLevel < 10)
        {
            SoundManager.PlaySound(SoundManager.UpgradeSound);  
            HelpScreenScript.TSocialMediaMarketingBool = true;
            WP.Money -= SocialMediaPM.upgradeCost;
            SocialMediaPM.upgradeCost += 50;
            SocialMediaPM.Upgrade();
            SVS.UpdateUI();
            InitiateBuildTimer(SocialMediaButton.GetComponent<Button>(), SocialMediaTimer);
        }
              else{
                if(!warning.activeSelf){
                    warning.SetActive(true);
                }
        }
    }

    public void SocialMediaUpgradeEffect(){

            SMMLevel += 1;
            WP.socialMediaStat += addSMStat;
            if(SMMLevel > 9){
                SocialMediaButton.SetActive(false);
            }
    }

    public void InitiateBuildTimer(Button button, GameObject timer){
        timer.SetActive(true);
        button.gameObject.SetActive(false);
    }
}

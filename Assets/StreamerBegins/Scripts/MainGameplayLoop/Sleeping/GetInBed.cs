﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInBed : MonoBehaviour
{
    public bool HoveringOnBed;
    public bool HoldingBed;

    public TimerScript TS;
    public UISliding UI;
    public PlayerState PS;

    public GameObject Light;
    public GameObject sleepButton;

    public WORLDPARAMETERS WP;

    public float streamDurationTimer;
    public float streamDurationBar;
    public GameObject fullWarning;

    public static bool isAsleep;
    Image sleepSprite;

    public Sprite sleepingSprite;
    public Sprite wakeUpSprite;
    public SoundManager SoundManager;
    void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
        sleepSprite = sleepButton.GetComponent<Image>();
    }
    private void OnMouseEnter()
    {
         // HoveringOnBed = true;
    if (!StreamChosenGame.amIStreaming && !UI.UIActive && !PartTimeScript.isWorking && !isAsleep)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 4.437178f, 7.626603f);
            this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, 0.8984127f, -0.01983786f);
            sleepButton.SetActive(true);
        }       
    }

    private void OnMouseExit()
    {
        if(!isAsleep){
        this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 2.631015f, 7.626603f);
        this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, -0.004668713f, -0.01983786f);
        sleepButton.SetActive(false);
        }
    }

    private void Update()
    {
        if (isAsleep == true)
        {
            if (WP.Health < 1f && !UI.UIActive)
            {
                WP.Health += Time.unscaledDeltaTime / streamDurationBar;
                TS.TimeStart(streamDurationTimer);
                PS.Sleeping();
                Light.SetActive(false);
                HelpScreenScript.TSleepBool = true;
                SoundManager.BGM.Stop();
                SoundManager.SleepBGM.enabled = true;
            }
            else
            {
                SoundManager.BGM.Play();
                SoundManager.SleepBGM.enabled = false;
                this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 2.631015f, 7.626603f);
                this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, -0.004668713f, -0.01983786f);
                sleepButton.SetActive(false);
                isAsleep =false;
                Light.SetActive(true);
                PS.Idle();
                sleepSprite.sprite = sleepingSprite;
            }
        }
        {
            
        }
    }
    public void Sleep()
    {
        if(WP.Health < 1)
        {
            GoToBed();
        }
        else
        {
            if(!fullWarning.activeSelf){
                    fullWarning.SetActive(true);
                }
            //say you have full health;
        }


    }

    private void GoToBed()
    {
        if (!isAsleep)
        {
            SoundManager.PlaySound(SoundManager.clickSound);
            isAsleep = true;
            sleepSprite.sprite = wakeUpSprite;
        }
        else
        {
            SoundManager.PlaySound(SoundManager.clickSound);
            SoundManager.BGM.Play();
            SoundManager.SleepBGM.enabled = false;
            PS.Idle();
            Light.SetActive(true);
            isAsleep = false;
            sleepSprite.sprite = sleepingSprite;
        }
    }
}

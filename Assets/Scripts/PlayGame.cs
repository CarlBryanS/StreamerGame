﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayGame: MonoBehaviour
{
  //  public GameObject Spawner;

    public WORLDPARAMETERS WP;
    public ResultScript RS;
    public DurationControl DC;
    public UISliding UI;
    public PlayerState PS;
    public ChatScript CS;
    public TimerScript TS;
    public float streamDurationBar;
    public float streamDurationTimer;
    public static bool amIStreaming;
    public static bool GOAHEAD;

    // public TMP_Text GameTrendText;

    public GameObject NotEnoughIndicator;

    public int GameTrend;
    public int GTMax;
    public int GTMin;

    public int tempViewers;
    public int tempFans;
    public int tempMoney;
    public RenderTexture FaceCamTexture;
    public Image PopularityImage;
    private void Awake()
    {
        GOAHEAD = false;
        WP.tempHealth = WP.Health;
        WP.tempEnergy = WP.Energy;
        GameTrend = Random.Range(GTMin, GTMax);
        popularityIndicator();
       // GameTrendText.SetText(GameTrend.ToString());
    }

    public void ResetGameTrends()
    {
        GameTrend = Random.Range(GTMin, GTMax);
     //   GameTrendText.SetText(GameTrend.ToString());
    }

    private void Update()
    {
        checkIfStreaming();
        if (amIStreaming && GOAHEAD == true)
        {
            WP.streamTime += Time.unscaledDeltaTime;
            WP.Health -= Time.unscaledDeltaTime / streamDurationBar;
            WP.Energy -= Time.unscaledDeltaTime / streamDurationBar;
            TS.TimeStart(streamDurationTimer);
            checkIfStreamEnded();
            PS.Typing();

           
          //  Spawner.SetActive(true);
        }
        else
        {
//something
        }


    }
    public void Stream()
    {
        WP.tempEnergy = WP.Energy;
        WP.tempHealth = WP.Health;

        tempFans = WP.Fans;
        tempMoney = WP.Money;
        tempViewers = WP.Viewers;
       // WP.Viewers = 0;
        DC.SubtractFromSlider();
        if (DC.DurationValue != 0)
        {

            if (WP.Energy >= DC.DurationValue && WP.Health >= DC.DurationValue)
            {
                
                WP.tempHealth -= DC.DurationValue;
                WP.tempEnergy -= DC.DurationValue;
                

                WP.Viewers = Mathf.Clamp(Random.Range(1,GameTrend) * DC.ReturnDurationInt(), ReturnViewerMinimum(WP.Fans), WP.viewerCap);
                RS.ViewersForTheDay = WP.Viewers;

                
               // RS.ViewersForTheDay += Mathf.Clamp(Random.Range(0, GameTrend), WP.Fans, WP.viewerCap);

                WP.Fans += Mathf.Clamp((Random.Range(0, WP.Viewers) +WP.socialMediaStat), 0, WP.Viewers);
                RS.FansGainedValue = WP.Fans - tempFans;
                //RS.FansGainedValue += Mathf.Clamp((Random.Range(0, WP.Viewers) +WP.socialMediaStat), 0, WP.Viewers);

                WP.Money += Mathf.Clamp((WP.Fans + (GameTrend)) * DC.ReturnDurationInt(), 0, WP.Viewers);
                RS.MoneyGainedValue = WP.Money - tempMoney;
               // RS.MoneyGainedValue += Mathf.Clamp((WP.Fans + (GameTrend)) * DC.ReturnDurationInt(), 0, WP.Viewers);



                
                amIStreaming = true;
                UI.CloseGameScreen();
                StartCoroutine("CameraPerspective");
                NotEnoughIndicator.SetActive(false);
                HelpScreenScript.TPCBool = true;

                WP.ControlStreamUI(false);
                CS.Invoke("DonationCheck", 1);
            }
            else
            {
               NotEnoughIndicator.SetActive(true);
            }
        }
    }

    void checkIfStreaming()
    {
        if (WP.Health <= WP.tempHealth || WP.Energy <= WP.tempEnergy)
        {         
            amIStreaming = false;
            FindObjectOfType<SoundManager>().Typing.Stop();
        }
    }

    void checkIfStreamEnded()
    {
        if (WP.Health <= WP.tempHealth || WP.Energy <= WP.tempEnergy)
        {       
            WP.streamTime = 0;
            GOAHEAD = false;
            UI.OpenResultsScreen();
            PS.Idle();
            WP.ControlStreamUI(true);
            UI.RoomPerspective();
            UI.RoomCamera.targetTexture = null;
            UI.GameplayCamera.enabled = false;
            UI.RescaleFaceCameraBase();
            CS.ClearActiveChatters();
        }
    }

    public void DisableNotEnoughIndicator()
    {
        NotEnoughIndicator.SetActive(false);
    }


    public int ReturnViewerMinimum(int number)
    {
        if(number>= WP.viewerCap)
        {
            number = WP.viewerCap;
        }
        return number;
    }

    public void popularityIndicator(){
        if(this.GameTrend > 0 && this.GameTrend <40){
            PopularityImage.sprite = WP.popularityImages[0];
        }
        else if(this.GameTrend > 40 && this.GameTrend <60){
            PopularityImage.sprite = WP.popularityImages[1];
        }
        else if(this.GameTrend > 60 && this.GameTrend <90){
            PopularityImage.sprite = WP.popularityImages[2];
        }
        else if(this.GameTrend > 90){
            PopularityImage.sprite = WP.popularityImages[3];
        }
    }


    IEnumerator CameraPerspective(){
        if(amIStreaming){
            UI.StreamPerspective();          
            yield return new WaitForSeconds(2);
            UI.RoomCamera.targetTexture = FaceCamTexture;
            UI.GameplayCamera.enabled = true;
            UI.RescaleFaceCamera();
            yield return new WaitForSeconds(1);
            FindObjectOfType<SoundManager>().playTypingSound();
            GOAHEAD = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayGame: MonoBehaviour
{
    public GameObject Spawner;

    public WORLDPARAMETERS WP;
    public ResultScript RS;
    public DurationControl DC;
    public UISliding UI;
    public PlayerState PS;

    public TimerScript TS;
    public float streamDurationBar;
    public float streamDurationTimer;
    public static bool amIStreaming;

    // public TMP_Text GameTrendText;

    public GameObject NotEnoughIndicator;

    public int GameTrend;
    public int GTMax;
    public int GTMin;

    public int tempViewers;
    public int tempFans;
    public int tempMoney;

    private void Awake()
    {
        WP.tempHealth = WP.Health;
        WP.tempEnergy = WP.Energy;
        GameTrend = Random.Range(GTMin, GTMax);
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
        if (amIStreaming)
        {
            WP.Health -= Time.unscaledDeltaTime / streamDurationBar;
            WP.Energy -= Time.unscaledDeltaTime / streamDurationBar;
            TS.TimeStart(streamDurationTimer);
            checkIfStreamEnded();
            PS.Typing();
            Spawner.SetActive(true);
        }
        else
        {
            Spawner.SetActive(false);
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

                WP.Viewers = Mathf.Clamp(Random.Range(1,GameTrend) * DC.ReturnDurationInt(), WP.Fans, WP.viewerCap);
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
                NotEnoughIndicator.SetActive(false);
                FindObjectOfType<SoundManager>().playTypingSound();
                HelpScreenScript.TPCBool = true;
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
            UI.OpenResultsScreen();
            PS.Idle();
        }
    }

    public void DisableNotEnoughIndicator()
    {
        NotEnoughIndicator.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayGame: MonoBehaviour
{
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
        if(amIStreaming)
        {
            WP.Health -= Time.unscaledDeltaTime / streamDurationBar;
            WP.Energy -= Time.unscaledDeltaTime / streamDurationBar;
            TS.TimeStart(streamDurationTimer);
            checkIfStreamEnded();
            PS.Typing();
        }


    }
    public void Stream()
    {
        WP.tempEnergy = WP.Energy;
        WP.tempHealth = WP.Health;
        DC.SubtractFromSlider();
        if (DC.DurationValue != 0)
        {       
            if (WP.Energy >= DC.DurationValue && WP.Health >= DC.DurationValue)
            {
                
                WP.tempHealth -= DC.DurationValue;
                WP.tempEnergy -= DC.DurationValue;

                WP.Viewers += Mathf.Clamp((WP.Fans / 2 + (GameTrend)) / DC.ReturnDurationInt(), WP.Fans, WP.viewerCap);
                WP.Money += ((WP.Viewers / 2 + (GameTrend)) / DC.ReturnDurationInt());
                WP.Fans += Mathf.Clamp(((WP.Viewers * WP.socialMediaStat / 2) / DC.ReturnDurationInt()), 0, WP.Viewers);

                RS.ViewersForTheDay += Mathf.Clamp((WP.Fans / 2 + (GameTrend)) / DC.ReturnDurationInt(), WP.Fans, WP.viewerCap);
                RS.MoneyGainedValue += ((WP.Viewers / 2 + (GameTrend)) / DC.ReturnDurationInt());
                RS.FansGainedValue += Mathf.Clamp(((WP.Viewers/2 * WP.socialMediaStat) / DC.ReturnDurationInt()), 0, WP.Viewers);
                amIStreaming = true;
                UI.CloseGameScreen();
                NotEnoughIndicator.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamChosenGame : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public ControlStreamTime CST;
    public ResultScript RS;
    public TimerScript TS;
    public PlayerState PS;
    public UISliding UI;
    public ChatScript CS;
    public DurationControl DC;
    public ActiveGame AG;
    public GameObject NotEnoughIndicator;
    public GameStats[] GS;
    public float streamDurationBar;
    public float streamDurationTimer;
    public static bool amIStreaming;
    public static bool GOAHEAD;
    public RenderTexture FaceCamTexture;

    int tempFans;
    int tempMoney;
    int tempViewers;

    void Update(){
        checkIfStreaming();
        if (amIStreaming && GOAHEAD == true)
        {           
           // WP.streamTime += Time.unscaledDeltaTime;
            WP.Health -= Time.unscaledDeltaTime / streamDurationBar;
            WP.Energy -= Time.unscaledDeltaTime / streamDurationBar;
            TS.TimeStart(streamDurationTimer);
            PS.Typing(); 
            checkIfStreamEnded();               
          //  Spawner.SetActive(true);
        }
        else
        {
//something
        }
    }

    public void Stream(){
        switch(ActiveGame.selectedGame){
            case"amongUs":
                Debug.Log(GS[0].GameTrend);
                startStream(GS[0].GameTrend);
                break;
            case"mineCraft":
                Debug.Log(GS[1].GameTrend);
                startStream(GS[1].GameTrend);
                break;
            case"csGO":
                Debug.Log(GS[2].GameTrend);
                startStream(GS[2].GameTrend);
                break;
            case"sims4":
                Debug.Log(GS[3].GameTrend);
                startStream(GS[3].GameTrend);
                break;
        }
    }
    void startStream(int GameTrend){
        WP.tempEnergy = WP.Energy;
        WP.tempHealth = WP.Health;

        tempFans = WP.Fans;
        tempMoney = WP.Money;
        tempViewers = WP.Viewers;
        //WP.Viewers = 0;
        DC.getTargetValues();
        if (DC.DurationValue != 0)
        {
            if (WP.Energy >= DC.DurationValue && WP.Health >= DC.DurationValue)
            {
                AG.ResetHighlights();
                WP.tempHealth -= DC.DurationValue;
                WP.tempEnergy -= DC.DurationValue;
                

                WP.Viewers = Mathf.Clamp(Random.Range(1,GameTrend) * DC.ReturnDurationInt(), ReturnViewerMinimum(WP.Fans), WP.viewerCap);
                RS.ViewersForTheDay = WP.Viewers;
                WP.Fans += fanLimit(Mathf.Clamp((Random.Range(0, WP.Viewers) +WP.socialMediaStat) * DC.ReturnDurationInt(), 0, WP.Viewers));
                RS.FansGainedValue = WP.Fans - tempFans;
                WP.Money += Mathf.Clamp((WP.Fans + (GameTrend)) * DC.ReturnDurationInt(), 0, WP.Viewers);
                RS.MoneyGainedValue = WP.Money - tempMoney;
              
                amIStreaming = true;
                UI.CloseGameScreen();
                StartCoroutine("CameraPerspective");
                NotEnoughIndicator.SetActive(false);
                HelpScreenScript.TPCBool = true;

                WP.ControlStreamUI(false);
                CS.InvokeRepeating("DonationCheck", 5, 5);
            }
            else
            {
               NotEnoughIndicator.SetActive(true);
            }
        }
    }
    
    int hardMoneyLimit(){
        return 1;
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
            Debug.Log("test");
            CS.CancelInvoke("DonationCheck");   
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
            streamDurationBar = 20;
            streamDurationTimer =20;
            CST.ResetTimeVisual();
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

    int fanLimit(int num){
        if(WP.Fans >= WP.viewerCap){
            Debug.Log("fan max");
            return 0;
        }
        else{
            Debug.Log("fan not max");
            return num;
        }
    }
}

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
    public GameObject streamButton;
    public float streamDurationBar;
    public float streamDurationTimer;
    public static bool amIStreaming;
    public static bool GOAHEAD;
    public RenderTexture FaceCamTexture;
    public miniGameState mgs;

    int tempFans;
    int tempMoney;
    int tempViewers;
    float tempCurrentHour;

    public GameObject warning;
    public GameObject warning2;
    public bool temptime;
    void start(){
        temptime = false;
    }

    void Update(){
        if(temptime==true){
            TS.TimeStart(0.4f);
        }
        checkIfStreaming();
        if (amIStreaming)
        {     
   
           // WP.streamTime += Time.unscaledDeltaTime;
           // WP.Health -= Time.unscaledDeltaTime / streamDurationBar;
           // WP.Energy -= Time.unscaledDeltaTime / streamDurationBar;
            WP.Health = WP.tempHealth;
            WP.Energy = WP.tempEnergy;
            if(Mathf.Abs(Mathf.RoundToInt(tempCurrentHour)) !=Mathf.Abs(Mathf.RoundToInt(TimerScript.currentHour)) && DC.DurationValue != 24){
                TS.TimeStart(2f);
            }
            checkIfStreamEnded();
            if(GOAHEAD == true){
                PS.Typing(); 
            }

        }
    }

    public void Stream(){
        switch(ActiveGame.selectedGame){
            case"amongUs":
                startStream(GS[0].GameTrend);
                break;
            case"mineCraft":
                startStream(GS[1].GameTrend);
                break;
            case"csGO":
                startStream(GS[2].GameTrend);
                break;
            case"sims4":
                startStream(GS[3].GameTrend);
                break;
            default:
                if(!warning.activeSelf){
                    warning.SetActive(true);
                }
                //Debug.Log("streaming game not found");
                break;
        }
    }
    void startStream(int GameTrend){
        tempCurrentHour = TS.getNextTime(ControlStreamTime.StreamTime);
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
                streamButton.SetActive(false);
                if(DC.DurationValue == 24){
                    TS.day +=1;
                    TS.ShittyFix();
                }
                mgs.gameEnabled();
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
                HelpScreenScript.TPCBool = true;

                WP.ControlStreamUI(false);
                CS.InvokeRepeating("DonationCheck", 5, 5);
            }
            else
            {
                if(!warning2.activeSelf){
                    warning2.SetActive(true);
                }
            }
        }
    }
    
    int hardMoneyLimit(){
        return 1;
    }

    void checkIfStreaming()
    {
        if (miniGameState.State == miniGameState.mgState.paused)//WP.Health <= WP.tempHealth || WP.Energy <= WP.tempEnergy)
        {         
            //amIStreaming = false;
            CS.CancelInvoke("DonationCheck"); 
        }
    }

    void checkIfStreamEnded()
    {
        if (miniGameState.State == miniGameState.mgState.stopped)//WP.Health <= WP.tempHealth || WP.Energy <= WP.tempEnergy)
        {    
            amIStreaming = false;
            CS.CancelInvoke("DonationCheck");   
            WP.streamTime = 0;          
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
            WP.Health = Mathf.Round(WP.Health*100)/100;
            WP.Energy = Mathf.Round(WP.Energy*100)/100;
            ActiveGame.selectedGame = "";
            GOAHEAD = false;
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
            Cursor.visible = false;
            UI.StreamPerspective();          
            yield return new WaitForSeconds(2);
            UI.RoomCamera.targetTexture = FaceCamTexture;
            UI.GameplayCamera.enabled = true;
            UI.RescaleFaceCamera();
            yield return new WaitForSeconds(1);
            GOAHEAD = true;
            Cursor.visible = true;
        }
    }

    int fanLimit(int num){
        if(WP.Fans >= WP.viewerCap){
            return 0;
        }
        else{
            return num;
        }
    }
}

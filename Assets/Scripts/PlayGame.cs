/*using System.Collections;
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
    public ActiveGame AG;
    public float streamDurationBar;
    public float streamDurationTimer;
    public static bool amIStreaming;
    public static bool GOAHEAD;

    // public TMP_Text GameTrendText;

    public GameObject NotEnoughIndicator;

    public int tempViewers;
    public int tempFans;
    public int tempMoney;
    public RenderTexture FaceCamTexture;
 
    private void Awake()
    {
        GOAHEAD = false;
        WP.tempHealth = WP.Health;
        WP.tempEnergy = WP.Energy;
        
       // GameTrendText.SetText(GameTrend.ToString());
    }

    private void Update()
    {
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
    public void Stream()
    {
        /*
        WP.tempEnergy = WP.Energy;
        WP.tempHealth = WP.Health;

        tempFans = WP.Fans;
        tempMoney = WP.Money;
        tempViewers = WP.Viewers;
       // WP.Viewers = 0;
       
        if (DC.DurationValue != 0)
        {

            if (WP.Energy >= DC.DurationValue && WP.Health >= DC.DurationValue)
            {
                AG.ResetHighlights();
                WP.tempHealth -= DC.DurationValue;
                WP.tempEnergy -= DC.DurationValue;
                

                WP.Viewers = Mathf.Clamp(Random.Range(1,GameTrend) * DC.ReturnDurationInt(), ReturnViewerMinimum(WP.Fans), WP.viewerCap);
                RS.ViewersForTheDay = WP.Viewers;

                
               // RS.ViewersForTheDay += Mathf.Clamp(Random.Range(0, GameTrend), WP.Fans, WP.viewerCap);

                WP.Fans += Mathf.Clamp((Random.Range(0, WP.Viewers) +WP.socialMediaStat) * DC.ReturnDurationInt(), 0, WP.Viewers);
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
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mcGameScript : MonoBehaviour
{
    public UISliding UI;
    public TMP_Text mcGoalText;
    public TMP_Text timerText;
    public TMP_Text resultText;
    public static int mcPoints;
    public static int mcGoal;
    public static bool mcActive;
    public static bool mcGotHit;

    float time;
    public SoundManager SoundManager;
    // Start is called before the first frame update
        void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

    void OnEnable()
    {
        mcGotHit = false;
        mcActive =true;
        mcPoints = 0;
        mcGoal =10;
        time = ControlStreamTime.StreamTime + 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            mcGoalText.SetText("Kill " + mcGoal.ToString() + " Enemies: " + mcPoints.ToString()+ "/" + mcGoal.ToString());
            SoundManager.BGM.Stop(); 
            SoundManager.MCBGM.enabled = true;
            time -= Time.unscaledDeltaTime;
            timerText.SetText("Time Left: " + Mathf.RoundToInt(time));
            didThePlayerWin();
            if(Input.GetMouseButtonDown(0)){
                SoundManager.playShootSound2();    
            }
        }
    }

    void didThePlayerWin(){
        if(mcPoints >= mcGoal){
            mcActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();       
            SoundManager.PlaySound(SoundManager.miniGameWinSound);   
            SoundManager.MCBGM.enabled = false;
  
            
        }
        else if(mcGotHit|| time <= 0){
            mcActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Lost!");
            UI.OpenGameResultScreen();     
            SoundManager.PlaySound(SoundManager.miniGameLoseSound);  
            SoundManager.MCBGM.enabled = false;         
        }
    }

    public void ConfirmGameResult(){
        SoundManager.BGM.Play(); 
        miniGameState.State = miniGameState.mgState.stopped;
        UI.CloseGameResultScreen();
    }

}


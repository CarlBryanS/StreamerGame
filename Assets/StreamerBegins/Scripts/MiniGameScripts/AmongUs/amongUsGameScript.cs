using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class amongUsGameScript : MonoBehaviour
{
    public UISliding UI;
    public TMP_Text amongUsGoalText;
    public TMP_Text timerText;
    public TMP_Text resultText;
    public static int amongUsPoints;
    public static int amongUsGoal;
    public static bool amongUsActive;
    public SoundManager SoundManager;

    float time;
    // Start is called before the first frame update
    void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

    void OnEnable()
    {
        amongUsActive =true;
        amongUsPoints = 0;
        amongUsGoal = 10;
        time = ControlStreamTime.StreamTime + 20;
        timerText.SetText(Mathf.RoundToInt(time).ToString());
        amongUsGoalText.SetText(amongUsGoal.ToString() + "		                " + amongUsPoints.ToString()+ "      " + amongUsGoal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            SoundManager.BGM.Stop(); 
            SoundManager.AmongUsBGM.enabled = true;
            if(WordManager.playerStarted){
                amongUsGoalText.SetText(amongUsGoal.ToString() + "		                " + amongUsPoints.ToString()+ "      "  + amongUsGoal.ToString());
                time -= Time.unscaledDeltaTime;
                timerText.SetText(Mathf.RoundToInt(time).ToString());
                didThePlayerWin();
            }    

        }
    }

    void didThePlayerWin(){
        if(amongUsPoints >= amongUsGoal){
            SoundManager.AmongUsBGM.enabled = false;
            amongUsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();       
            SoundManager.PlaySound(SoundManager.miniGameWinSound);            
        }
        else if(time <= 0){
            SoundManager.AmongUsBGM.enabled = false;
            amongUsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Lost!");
            UI.OpenGameResultScreen();     
            SoundManager.PlaySound(SoundManager.miniGameLoseSound);   
        }
    }

    public void ConfirmGameResult(){
        SoundManager.BGM.Play(); 
        miniGameState.State = miniGameState.mgState.stopped;
        UI.CloseGameResultScreen();
    }

}

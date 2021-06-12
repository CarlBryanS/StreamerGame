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

    float time;
    // Start is called before the first frame update
    void OnEnable()
    {
        amongUsActive =true;
        amongUsPoints = 0;
        amongUsGoal = ControlStreamTime.StreamTime;
        time = ControlStreamTime.StreamTime + 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            amongUsGoalText.SetText("Type " + amongUsGoal.ToString() + " Sentences: " + amongUsPoints.ToString()+ "/" + amongUsGoal.ToString());
            time -= Time.unscaledDeltaTime;
            timerText.SetText("Time Left: " + Mathf.RoundToInt(time));
            didThePlayerWin();
        }
    }

    void didThePlayerWin(){
        if(amongUsPoints >= amongUsGoal){
            amongUsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();       
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameWinSound);   
        }
        else if(time <= 0){
            amongUsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Lost!");
            UI.OpenGameResultScreen();     
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameLoseSound);   
        }
    }

    public void ConfirmGameResult(){
        miniGameState.State = miniGameState.mgState.stopped;
        UI.CloseGameResultScreen();
    }

}

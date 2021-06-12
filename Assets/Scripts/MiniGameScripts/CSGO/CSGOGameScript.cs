using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CSGOGameScript : MonoBehaviour
{
    public UISliding UI;
    public TMP_Text csgoGoalText;
    public TMP_Text timerText;
    public TMP_Text resultText;
    public static int csgoPoints;
    public static int csgoGoal;
    public static bool csgoActive;

    float time;
    // Start is called before the first frame update
    void OnEnable()
    {
        csgoActive =true;
        csgoPoints = 0;
        csgoGoal = ControlStreamTime.StreamTime;
        time = ControlStreamTime.StreamTime + 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            FindObjectOfType<SoundManager>().BGM.Stop(); 
            FindObjectOfType<SoundManager>().CSGOBGM.enabled = true;
            csgoGoalText.SetText("Kill " + csgoGoal.ToString() + " Enemies: " + csgoPoints.ToString()+ "/" + csgoGoal.ToString());
            time -= Time.unscaledDeltaTime;
            timerText.SetText("Time Left: " + Mathf.RoundToInt(time));
            didThePlayerWin();
            if(Input.GetMouseButtonDown(0)){
                FindObjectOfType<SoundManager>().playShootSound();    
            }
        }
    }

    void didThePlayerWin(){
        if(csgoPoints >= csgoGoal){
            csgoActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();   
            FindObjectOfType<SoundManager>().CSGOBGM.enabled = false;      
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameWinSound);    
        }
        else if(time <= 0){
            csgoActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Lost!");
            UI.OpenGameResultScreen();     
            FindObjectOfType<SoundManager>().CSGOBGM.enabled = false;
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameLoseSound);   
        }
    }

    public void ConfirmGameResult(){

        FindObjectOfType<SoundManager>().BGM.Play();
        miniGameState.State = miniGameState.mgState.stopped;
        UI.CloseGameResultScreen();
    }

    //spawn on enemy on designated spots
    //click on enemy
    //gain points
    //if goal points not met
    //lose
    //chat kekws
    //if goal points met
    //win
    //chat pogs out
    //timer paused

}

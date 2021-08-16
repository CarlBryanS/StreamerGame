using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class simsGameScript : MonoBehaviour
{
    public UISliding UI;
    public TMP_Text simsGoalText;
    public TMP_Text HealthText;
    public TMP_Text timeText;
    public TMP_Text resultText;
    public static int simsPoints;
    public static int simsGoal;
    public static bool simsActive;
    public Camera gameplaycam;

    public GameObject player;

    float time;
    public static float simsHealth;
    // Start is called before the first frame update
    void OnEnable()
    {
        simsActive =true;
        simsPoints = 0;
        simsGoal = 20;
        simsHealth = 2;
        time = ControlStreamTime.StreamTime +4;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            FindObjectOfType<SoundManager>().BGM.Stop(); 
            FindObjectOfType<SoundManager>().SimsBGM.enabled = true; 
            simsGoalText.SetText("Catch " + simsGoal.ToString() + " Money: " + simsPoints.ToString()+ "/" + simsGoal.ToString());
            time -= Time.unscaledDeltaTime;
            timeText.SetText("Time Left:" + Mathf.RoundToInt(time));
            HealthText.SetText("Health Left: " + Mathf.RoundToInt(simsHealth));
            didThePlayerWin();
            Vector3 mouseposition = gameplaycam.ScreenToWorldPoint(Input.mousePosition);
            mouseposition.z = 0;
            player.transform.position = mouseposition;                    
        }
    }

    void didThePlayerWin(){
        if(simsPoints >= simsGoal){
            FindObjectOfType<SoundManager>().SimsBGM.enabled = false;
            simsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();       
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameWinSound);   
            
        }
        else if(simsHealth <= 0 || time <= 0){
            FindObjectOfType<SoundManager>().SimsBGM.enabled = false;
            simsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Lost!");
            UI.OpenGameResultScreen();     
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameLoseSound);   
        }
    }

    public void ConfirmGameResult(){
        FindObjectOfType<SoundManager>().BGM.Play(); 
        miniGameState.State = miniGameState.mgState.stopped;
        UI.CloseGameResultScreen();
    }

}


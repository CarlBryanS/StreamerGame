using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class simsGameScript : MonoBehaviour
{
    public UISliding UI;
    public TMP_Text simsGoalText;
    public TMP_Text HealthText;
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
        simsGoal = ControlStreamTime.StreamTime + 10;
        simsHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            simsGoalText.SetText("Catch " + simsGoal.ToString() + " Money: " + simsPoints.ToString()+ "/" + simsGoal.ToString());
            //time -= Time.unscaledDeltaTime;
            HealthText.SetText("Health Left: " + Mathf.RoundToInt(simsHealth));
            didThePlayerWin();
            Debug.Log(gameplaycam.ScreenToWorldPoint(Input.mousePosition));
            Vector3 mouseposition = gameplaycam.ScreenToWorldPoint(Input.mousePosition);
            mouseposition.z = 0;
            player.transform.position = mouseposition;
        }
    }

    void didThePlayerWin(){
        if(simsPoints >= simsGoal){
            simsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
            resultText.SetText("You Won!");
            UI.OpenGameResultScreen();       
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().miniGameWinSound);   
        }
        else if(simsHealth <= 0){
            simsActive = false;
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


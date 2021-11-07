using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
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
    public UnityEvent YouWin;
    public UnityEvent YouLose;


    public GameObject player;

    float time;
    public static float simsHealth;
    public SoundManager SoundManager;
    // Start is called before the first frame update
        void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }

    void OnEnable()
    {
        simsActive =true;
        simsPoints = 0;
        simsGoal = 20;
        simsHealth = 2;
        time = ControlStreamTime.StreamTime +10;
    }
    void OnDisable()
    {
        simsActive =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(miniGameState.State ==miniGameState.mgState.onGoing&& StreamChosenGame.GOAHEAD){
            SoundManager.BGM.Stop(); 
            SoundManager.SimsBGM.enabled = true; 
            simsGoalText.SetText("Catch " + simsGoal.ToString() + " Cookies: " + simsPoints.ToString()+ "/" + simsGoal.ToString());
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
            SoundManager.SimsBGM.enabled = false;
            simsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
           // resultText.SetText("You Won!");
           YouWin.Invoke();
            UI.OpenGameResultScreen();       
            SoundManager.PlaySound(SoundManager.miniGameWinSound);   
            
        }
        else if(simsHealth <= 0 || time <= 0){
            SoundManager.SimsBGM.enabled = false;
            simsActive = false;
            miniGameState.State = miniGameState.mgState.paused;
          //  resultText.SetText("You Lost!");
            YouLose.Invoke();
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


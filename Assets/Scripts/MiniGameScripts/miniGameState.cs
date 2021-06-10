using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGameState : MonoBehaviour
{
    public enum mgState{
        paused,
        onGoing,
        stopped
    }
    public GameObject csgoGame;
    public GameObject amongUsGame;
    public GameObject mineCraftGame;
    public GameObject sims4Game;
    public ActiveGame AG;
    public static mgState State;
    void Start(){
        DisableAll();
        State = mgState.paused;
    }

    void Update(){
        if(miniGameState.State == miniGameState.mgState.paused){
            DisableAll();
        }
    }
    public void gameEnabled(){
        switch(ActiveGame.selectedGame){
           
            case"amongUs":
                State = mgState.onGoing;
                amongUsGame.SetActive(true);
                csgoGame.SetActive(false);
                mineCraftGame.SetActive(false);
                sims4Game.SetActive(false);
                break;
            case"mineCraft":
                State = mgState.onGoing;
                amongUsGame.SetActive(false);
                csgoGame.SetActive(false);
                mineCraftGame.SetActive(true);
                sims4Game.SetActive(false);
                break;
            case"csGO":
                State = mgState.onGoing;
                amongUsGame.SetActive(false);
                csgoGame.SetActive(true);
                mineCraftGame.SetActive(false);
                sims4Game.SetActive(false);
                break;
            case"sims4":
                State = mgState.onGoing;
                amongUsGame.SetActive(false);
                csgoGame.SetActive(false);
                mineCraftGame.SetActive(false);
                sims4Game.SetActive(true);
                break;
        }   
    }

    public void DisableAll(){
                amongUsGame.SetActive(false);
                csgoGame.SetActive(false);
                mineCraftGame.SetActive(false);
                sims4Game.SetActive(false);
    }
}

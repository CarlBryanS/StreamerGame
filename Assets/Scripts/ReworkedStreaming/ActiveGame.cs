using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static string selectedGame;

    public GameObject amongUsHighlight;
    public GameObject csGoHighlight;
    public GameObject mcHighlight;
    public GameObject sims4Highlight;
    public void getActiveGame(string gameName){
        switch(gameName){
            case"amongUs":
                amongUsHighlight.SetActive(true);
                csGoHighlight.SetActive(false);
                mcHighlight.SetActive(false);
                sims4Highlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"csGO":
                csGoHighlight.SetActive(true);
                amongUsHighlight.SetActive(false);
                mcHighlight.SetActive(false);
                sims4Highlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"mineCraft":
                mcHighlight.SetActive(true);
                sims4Highlight.SetActive(false);
                amongUsHighlight.SetActive(false);
                csGoHighlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"sims4":
                sims4Highlight.SetActive(true);
                amongUsHighlight.SetActive(false);
                csGoHighlight.SetActive(false);
                mcHighlight.SetActive(false);
                selectedGame = gameName;
                break;
            default:
                Debug.Log("game not found");
                break;
        }
    }

    public void ResetHighlights(){
        selectedGame = "";
        amongUsHighlight.SetActive(false);
        csGoHighlight.SetActive(false);
        mcHighlight.SetActive(false);
        sims4Highlight.SetActive(false);
    }
}

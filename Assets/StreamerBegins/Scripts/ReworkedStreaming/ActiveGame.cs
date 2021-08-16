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

    public static ActiveGame instance;
    void Awake(){
    }
    public void getActiveGame(string gameName){
        switch(gameName){
            case"amongUs":
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);  
                amongUsHighlight.SetActive(true);
                csGoHighlight.SetActive(false);
                mcHighlight.SetActive(false);
                sims4Highlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"csGO":
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);  
                csGoHighlight.SetActive(true);
                amongUsHighlight.SetActive(false);
                mcHighlight.SetActive(false);
                sims4Highlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"mineCraft":
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);  
                mcHighlight.SetActive(true);
                sims4Highlight.SetActive(false);
                amongUsHighlight.SetActive(false);
                csGoHighlight.SetActive(false);
                selectedGame = gameName;
                break;
            case"sims4":
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);  
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
        amongUsHighlight.SetActive(false);
        csGoHighlight.SetActive(false);
        mcHighlight.SetActive(false);
        sims4Highlight.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject screen;
    public UISliding UI;
    public TutorialScript tutorial;
    public void TutorialCloseGame(){
        if(!screen.activeSelf && tutorial.index >10){
            UI.CloseGameScreen();
        }
    }
}

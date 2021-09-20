using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartStream : MonoBehaviour
{
    public UISliding UI;
    public TutorialScript tutorialScript;

    void OnMouseDown()
    {
        if(DialogueScript.TextActive)return;
        if (!StreamChosenGame.amIStreaming && !UI.UIActive && !WORLDPARAMETERS.amIUIHovered && !PartTimeScript.isWorking &&!GetInBed.isAsleep)
        {
            UI.OpenGameScreen();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialStartStream : MonoBehaviour
{
    public UISliding UI;
    public TutorialScript tutorialScript;
    public UnityEvent ProgressTo1;

    void OnMouseDown()
    {
        if(DialogueScript.TextActive)return;
        if (!StreamChosenGame.amIStreaming && !UI.UIActive && !WORLDPARAMETERS.amIUIHovered && !PartTimeScript.isWorking &&!GetInBed.isAsleep)
        {
            if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Start){
                ProgressTo1.Invoke();
                TutorialTriggerCheck.State= TutorialTriggerCheck.TutorialState.PC;
                UI.OpenGameScreen();
            }     
        }
        
    }
}

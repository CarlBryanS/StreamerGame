using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOutlines : OutlineEnablerReworked
{
    public UISliding UI;
    public TutorialScript tutorialScript;
    public override void OnMouseEnter()
    {
        switch(this.gameObject.name){
            case "BedCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Sleep){
                    Highlight();
                }       
                break;
            case "PCCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.PC){
                    Highlight();
                }       
                break;
            case "DoorCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Door){
                    Highlight();
                }       
                break;
        }


    }
    void Highlight(){
        if(!DialogueScript.TextActive && !UI.UIActive){
            base.OnMouseEnter();
        }
    }
    void RemoveHighlight(){
        if(!UI.UIActive){
            base.OnMouseExit();
        }
    }

    public override void OnMouseExit()
    {
        switch(this.gameObject.name){
            case "BedCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Sleep){
                    RemoveHighlight();
                }       
                break;
            case "PCCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.PC){
                    RemoveHighlight();
                }       
                break;
            case "DoorCollider":
                if(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Door){
                    RemoveHighlight();
                }       
                break;
        }

    }
}

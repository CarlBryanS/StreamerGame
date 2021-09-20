using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOutlines : OutlineEnablerReworked
{
    public UISliding UI;
    public TutorialScript tutorialScript;
    public override void OnMouseEnter()
    {
        if(!DialogueScript.TextActive && !UI.UIActive){
            base.OnMouseEnter();
        }

    }

    public override void OnMouseExit()
    {
        if(!DialogueScript.TextActive && !UI.UIActive){
            base.OnMouseExit();
        }

    }
}

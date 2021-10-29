using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayOutline : OutlineEnablerReworked
{
    public UISliding UI;
    public override void OnMouseEnter()
    {
        if(!UI.UIActive && !StreamChosenGame.amIStreaming && !WORLDPARAMETERS.amIUIHovered && !PartTimeScript.isWorking && !GetInBed.isAsleep){
            base.OnMouseEnter();
        }
    }
    public override void OnMouseExit()
    {
        //if(!UI.UIActive && !StreamChosenGame.amIStreaming && !WORLDPARAMETERS.amIUIHovered && !PartTimeScript.isWorking && !GetInBed.isAsleep)
        //{
            base.OnMouseExit();
       // }
    }
}

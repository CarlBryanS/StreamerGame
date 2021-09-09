using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOutlines : OutlineEnablerReworked
{
    public override void OnMouseEnter()
    {
        if(!DialogueScript.TextActive)
        base.OnMouseEnter();
    }
}

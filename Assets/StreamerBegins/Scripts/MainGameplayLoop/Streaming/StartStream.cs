using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStream : MonoBehaviour
{
    public UISliding UI;

    void OnMouseDown()
    {
        if (!StreamChosenGame.amIStreaming && !UI.UIActive && !WORLDPARAMETERS.amIUIHovered && !PartTimeScript.isWorking &&!GetInBed.isAsleep)
        {
            UI.OpenGameScreen();
        }
        
    }
}

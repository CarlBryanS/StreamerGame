using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStream : MonoBehaviour
{
    public UISliding UI;

    void OnMouseDown()
    {
        if (!PlayGame.amIStreaming && !UI.UIActive && !WORLDPARAMETERS.amIUIHovered)
        {
            UI.OpenGameScreen();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineEnabler : MonoBehaviour
{
    public Outline[] Out;
    public UISliding UI;

    bool amIHovered;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        amIHovered = true;
    }

    private void OnMouseExit()
    {
        amIHovered = false;
    }

    private void Update()
    {
        if(amIHovered && !UI.UIActive && !PlayGame.amIStreaming && !WORLDPARAMETERS.amIUIHovered )
        {
            for (int i = 0; i < Out.Length; i++)
            {
                Out[i].enabled = true;
            }
           
        }
        else
        {
            for (int i = 0; i < Out.Length; i++)
            {
                Out[i].enabled = false;
            }
            
        }
    }

}

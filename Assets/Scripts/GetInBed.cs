using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInBed : MonoBehaviour
{
    public bool HoveringOnBed;
    public bool HoldingBed;

    public TimerScript TS;
    public UISliding UI;


    public WORLDPARAMETERS WP;

    public float streamDuration;
    private void OnMouseEnter()
    {
          HoveringOnBed = true;       
    }

    private void OnMouseExit()
    {
          HoveringOnBed = false;
    }

    private void Update()
    {
        checkIfSleeping();
        //sleep
        if(HoldingBed == true)
        {
           if(WP.Health <= 0.999f)
           {
                WP.Health += Time.unscaledDeltaTime / 2;
                TS.TimeStart(streamDuration);
            }

        }
    }

    void checkIfSleeping()
    {
        if (Input.GetMouseButtonDown(0) && HoveringOnBed && !UI.UIActive &&!PlayGame.amIStreaming)
        {
            HoldingBed = true;
        }
        else if (Input.GetMouseButtonUp(0) || !HoveringOnBed)
        {
            HoldingBed = false;
        }
            
    }
}

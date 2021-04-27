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
    public PlayerState PS;

    public GameObject Light;

    public WORLDPARAMETERS WP;

    public float streamDurationTimer;
    public float streamDurationBar;
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
        if (HoldingBed == true)
        {
            if (WP.Health <= 0.999f && !UI.UIActive)
            {
                WP.Health += Time.unscaledDeltaTime / streamDurationBar;
                TS.TimeStart(streamDurationTimer);
                PS.Sleeping();
                Light.SetActive(false);
                HelpScreenScript.TSleepBool = true;
            }
            else
            {
                PS.Idle();
            }

        }
        else
        {
            Light.SetActive(true);
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
            PS.Idle();
            HoldingBed = false;
        }
            
    }
}

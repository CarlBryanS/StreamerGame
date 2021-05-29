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
    public GameObject sleepButton;

    public WORLDPARAMETERS WP;

    public float streamDurationTimer;
    public float streamDurationBar;

    public static bool isAsleep;
    private void OnMouseEnter()
    {
         // HoveringOnBed = true;
    if (!StreamChosenGame.amIStreaming && !UI.UIActive && !PartTimeScript.isWorking && !isAsleep)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 4.437178f, 7.626603f);
            this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, 0.8984127f, -0.01983786f);
            sleepButton.SetActive(true);
        }       
    }

    private void OnMouseExit()
    {
        if(!isAsleep){
        this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 2.631015f, 7.626603f);
        this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, -0.004668713f, -0.01983786f);
        sleepButton.SetActive(false);
        }

        //HoveringOnBed = false;
    }

    private void Update()
    {
        //sleep
        if (isAsleep == true)
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
                this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 2.631015f, 7.626603f);
                this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, -0.004668713f, -0.01983786f);
                sleepButton.SetActive(false);
                isAsleep =false;
                Light.SetActive(true);
                PS.Idle();
            }
        }
        {
            
        }
    }
     public void Sleep()
    {
        if(WP.Health < 1){
            if(!isAsleep){
                isAsleep = true;
            }
            else{
                PS.Idle();
                Light.SetActive(true);
                isAsleep =false;
            }
        }
        else{
            //say you have full health;
        }


    }
}

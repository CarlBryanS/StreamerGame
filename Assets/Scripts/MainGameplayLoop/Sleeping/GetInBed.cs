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
    public GameObject fullWarning;

    public static bool isAsleep;
    Image sleepSprite;

    public Sprite sleepingSprite;
    public Sprite wakeUpSprite;
    void Start(){
        sleepSprite = sleepButton.GetComponent<Image>();
    }
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
        //fullWarning.SetActive(false);
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
            if (WP.Health < 1f && !UI.UIActive)
            {
                WP.Health += Time.unscaledDeltaTime / streamDurationBar;
                TS.TimeStart(streamDurationTimer);
                PS.Sleeping();
                Light.SetActive(false);
                HelpScreenScript.TSleepBool = true;
                FindObjectOfType<SoundManager>().BGM.Stop();
                FindObjectOfType<SoundManager>().SleepBGM.enabled = true;
            }
            else
            {
                Debug.Log("sleep ended");
                FindObjectOfType<SoundManager>().BGM.Play();
                FindObjectOfType<SoundManager>().SleepBGM.enabled = false;
                this.GetComponent<BoxCollider>().size = new Vector3(5.951694f, 2.631015f, 7.626603f);
                this.GetComponent<BoxCollider>().center = new Vector3(-0.8318317f, -0.004668713f, -0.01983786f);
                sleepButton.SetActive(false);
                isAsleep =false;
                Light.SetActive(true);
                PS.Idle();
                sleepSprite.sprite = sleepingSprite;
            }
        }
        {
            
        }
    }
     public void Sleep()
    {
        if(WP.Health < 1){
            if(!isAsleep){
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);       
                isAsleep = true;
                sleepSprite.sprite = wakeUpSprite;
            }
            else{
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickSound);   
                FindObjectOfType<SoundManager>().BGM.Play();
                FindObjectOfType<SoundManager>().SleepBGM.enabled = false;
                PS.Idle();
                Light.SetActive(true);
                isAsleep =false;
                sleepSprite.sprite = sleepingSprite;
            }
        }
        else{
            if(!fullWarning.activeSelf){
                    fullWarning.SetActive(true);
                }
            //say you have full health;
        }


    }
}

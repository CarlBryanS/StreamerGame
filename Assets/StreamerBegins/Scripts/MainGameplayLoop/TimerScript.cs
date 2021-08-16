using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public UISliding UI;

    public float day;
    float oldDay;

    public TMP_Text timeText;
    public TMP_Text daysText;

    public GameStats[] GS;
    public WORLDPARAMETERS WP;
    public BillsScript BS;

    public string hoursString;
    string minutesString;
    float dayNormalized ;
    float hoursPerDay;
    float minutesPerHour;

    public static float currentHour;
    public static float currentMinutes;
    // Start is called before the first frame update
    void Start()
    {
        currentHour = 8;
        oldDay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShittyFix(){
        daysText.SetText(Mathf.Floor(day).ToString());
    }

    public void TimeStart(float secondsPerDay)
    {     
        daysText.SetText(Mathf.Floor(day).ToString());
        day += Time.deltaTime / secondsPerDay;

        dayNormalized = day % 1f;

        hoursPerDay = 24f;
        minutesPerHour = 60f;
        
        hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");
        currentHour = Mathf.Floor(dayNormalized * hoursPerDay);
        //currentMinutes =Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour);
        timeText.SetText(hoursString + ":" + minutesString);

        if(Mathf.Floor(oldDay) < Mathf.Floor(day))
        {
            oldDay += 1;
            BS.CheckDays();
            for (int i = 0; i < GS.Length; i += 1)
            {               
                GS[i].ResetGameTrends();
                GS[i].popularityIndicator();
            }
        }
    }

    public float getNextTime(float jobTime){
        if((currentHour + jobTime) > 23){
            return (Mathf.Abs(24- (currentHour+jobTime)));
        }
        else{
            return currentHour + jobTime;
        }
    }
}

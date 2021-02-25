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

    public PlayGame[] PG;
    public WORLDPARAMETERS WP;
    public BillsScript BS;

    string hoursString;
    string minutesString;
    // Start is called before the first frame update
    void Start()
    {
        oldDay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        daysText.SetText(Mathf.Floor(day).ToString());
    }

    public void TimeStart(float secondsPerDay)
    {
        day += Time.deltaTime / secondsPerDay;

        float dayNormalized = day % 1f;

        float hoursPerDay = 24f;
        float minutesPerHour = 60f;
        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.SetText(hoursString + ":" + minutesString);

        if(Mathf.Floor(oldDay) < Mathf.Floor(day))
        {
            Debug.Log("New Day");
            oldDay += 1;
            BS.CheckDays();
            for (int i = 0; i < PG.Length; i += 1)
            {
                
                PG[i].ResetGameTrends();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarDecrease : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public Image bar;
    float barMarker;
    public float timer;

    public float refillRate;
    public float timerSpeed;

    public TMP_Text HealthVisual;
    public TMP_Text EnergyVisual;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       StartTimer();
    }

    public void StartTimer()
    {
        switch(this.gameObject.name)
        {
            case "Health":
                timer = WP.Health;           
                HealthVisual.SetText(Mathf.Round(timer * 100).ToString() + "/100");
                break;
            case "Energy":
                timer = WP.Energy;
                EnergyVisual.SetText(Mathf.Round(timer * 100).ToString()+ "/100");
                break;
        }
        barMarker = Mathf.Lerp(0, 1, timer);
        bar.fillAmount = barMarker;
    }
}

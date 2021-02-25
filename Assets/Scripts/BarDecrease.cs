using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDecrease : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public Image bar;
    float barMarker;
    public float timer;

    public float refillRate;
    public float timerSpeed;

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
                break;
            case "Energy":
                timer = WP.Energy;
                break;
        }
        barMarker = Mathf.Lerp(0, 1, timer);
        bar.fillAmount = barMarker;
    }
}

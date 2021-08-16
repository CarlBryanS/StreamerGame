using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseIndicator : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public DurationControl DC;
    public UISliding UI;

    public Image health;
    public Image energy;

    Image indicator;

    public static bool statRanOut;

    private void Start()
    {
        statRanOut = false;
        indicator = GetComponent<Image>();
    }

    private void Update()
    {
        if (UI.GameScreenActive)
        {
            switch (this.gameObject.name)
            {
                case "HealthDecreaseIndicator":
                    indicator.fillAmount = DC.ShittyConversion() + (1 - health.fillAmount);
                    checkIfCapped();
                    break;
                case "EnergyDecreaseIndicator":
                    indicator.fillAmount = DC.ShittyConversion()+ (1 - energy.fillAmount);
                    checkIfCapped();
                    break;
            }
        }
        else
        {
            indicator.fillAmount = 0;
        }

    }

    
    public void checkIfCapped(){
        if(indicator.fillAmount>=0.99 || (WP.Health - 0.042) <0|| (WP.Energy -0.042) <0){
            statRanOut = true;
        }
        else{
            statRanOut = false;
        }
    }
}

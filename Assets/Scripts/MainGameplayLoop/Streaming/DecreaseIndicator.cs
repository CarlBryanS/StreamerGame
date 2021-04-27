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

    private void Start()
    {
        indicator = GetComponent<Image>();
    }

    private void Update()
    {
        if (UI.GameScreenActive)
        {
            switch (this.gameObject.name)
            {
                case "HealthDecreaseIndicator":
                    indicator.fillAmount = DC.DurationSlider.value + (1 - health.fillAmount);
                    break;
                case "EnergyDecreaseIndicator":
                    indicator.fillAmount = DC.DurationSlider.value + (1 - energy.fillAmount);
                    break;
            }
        }
        else
        {
            indicator.fillAmount = 0;
        }

    }
}

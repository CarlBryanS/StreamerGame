using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DurationControl : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    //control slider
    public Slider DurationSlider;
    //confirm first then
    //input slider value to image fill
    public float DurationValue;

    public int returnedValue;

    public void SubtractFromSlider()
    {
        DurationValue = DurationSlider.value;
    }

    public int ReturnDurationInt()
    {
        if(DurationValue >=0.8f)
        {
            returnedValue = 1;
        }
        else if(DurationValue>= 0.5f)
        {
            returnedValue = 2;
        }
        else if(DurationValue >=0.2f)
        {
            returnedValue = 3;
        }
        else if(DurationValue <= 0.2f)
        {
            returnedValue = 4;
        }
        return returnedValue;
    }
}

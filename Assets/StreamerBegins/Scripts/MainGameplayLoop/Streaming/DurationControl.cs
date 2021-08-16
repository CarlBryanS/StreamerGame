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
    

    public void getTargetValues()
    {
        DurationValue = ShittyConversion();
    }

    public int ReturnDurationInt()
    {
        if(DurationValue >=0.8f)
        {
            returnedValue = 2;
        }
        else if(DurationValue>= 0.5f)
        {
            returnedValue = 1;
        }
        else if(DurationValue >=0.2f)
        {
            returnedValue = 1;
        }
        else if(DurationValue <= 0.2f)
        {
            returnedValue = 0;
        }
        return returnedValue;
    }

    public float ShittyConversion(){
        switch(ControlStreamTime.StreamTime){
            case 1:
                return 0.042f * 1;
            case 2:
                return 0.042f * 2;
            case 3:
                return 0.042f * 3;
            case 4:
                return 0.042f * 4;
            case 5:
                return 0.042f * 5;
            case 6:
                return 0.042f * 6;
            case 7:
                return 0.042f * 7;
            case 8:
                return 0.042f * 8;
            case 9:
                return 0.042f * 9;
            case 10:
                return 0.042f * 10;
            case 11:
                return 0.042f * 11;
            case 12:
                return 0.042f * 12;
            case 13:
                return 0.042f * 13;
            case 14:
                return 0.042f * 14;
            case 15:
                return 0.042f * 15;
            case 16:
                return 0.042f * 16;
            case 17:
                return 0.042f * 17;
            case 18:
                return 0.042f * 18;
            case 19:
                return 0.042f * 19;
            case 20:
                return 0.042f * 20;
            case 21:
                return 0.042f * 21;
            case 22:
                return 0.042f * 22;
            case 23:
                return 0.042f * 23;
            case 24:
                return 1;
            default:
                return 0;
        }
    }
    
}

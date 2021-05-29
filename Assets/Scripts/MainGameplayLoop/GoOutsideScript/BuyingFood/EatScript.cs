using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public SetVisualStats SVS;
    public float eatValue;
    public int foodPrice;

    float tempEnergy;

    public void Eat()
    {
        if (WP.Money >= foodPrice && WP.Energy < 1)
        {
            if(WP.Energy+ eatValue >= 1)
            {
                
                HelpScreenScript.TFoodBool = true;
                FindObjectOfType<SoundManager>().playEatSound();
                WP.Energy = 1;
            }
            else
            {
                HelpScreenScript.TFoodBool = true;
                FindObjectOfType<SoundManager>().playEatSound();
                WP.Energy += eatValue;
            }
            
            WP.Money -= foodPrice;
            SVS.UpdateUI();
        }
            
    }

    public void previewEat()
    {
        WP.Energy += eatValue;
    }
    public void stopPreview()
    {
       
    }
}

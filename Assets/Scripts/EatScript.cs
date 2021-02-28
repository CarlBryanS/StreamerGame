using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public float eatValue;
    public int foodPrice;

    public void Eat()
    {
        if (WP.Money >= foodPrice)
        {
            if(WP.Energy+ eatValue >= 1)
            {
                FindObjectOfType<SoundManager>().playEatSound();
                WP.Energy = 1;
            }
            else
            {
                FindObjectOfType<SoundManager>().playEatSound();
                WP.Energy += eatValue;
            }
            
            WP.Money -= foodPrice;
        }
            
    }
}

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
                WP.Energy = 1;
            }
            else
            {
                WP.Energy += eatValue;
            }
            
            WP.Money -= foodPrice;
        }
            
    }
}

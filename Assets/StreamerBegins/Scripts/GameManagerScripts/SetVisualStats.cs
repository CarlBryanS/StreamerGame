using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetVisualStats : MonoBehaviour
{
    WORLDPARAMETERS WP;
    public TMP_Text moneyText;
    public TMP_Text fansText;

    void Start(){
        WP = GetComponent<WORLDPARAMETERS>();
    }

   public void UpdateUI(){
       moneyText.SetText(WP.Money.ToString());
       fansText.SetText(WP.Fans.ToString());
    }

}

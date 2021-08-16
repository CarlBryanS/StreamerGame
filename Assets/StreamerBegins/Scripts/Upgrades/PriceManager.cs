using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceManager : MonoBehaviour
{
    public GameObject[] upgrades;

    public WORLDPARAMETERS WP;

    public TextMeshProUGUI upgradeText;

    public int upgradeCost;

    void Start()
    {
    }

    void Update()
    {
        thisPrice();
    }

    void thisPrice()
    {
        upgradeText.text = this.upgradeCost.ToString();
    }

    public void Upgrade()
    {
          //  for (int i = 0; i < upgrades.Length; i++)
         //   {
           //     upgrades[i].GetComponent<PriceManager>().upgradeCost += 25;
         //   }
           // upgradeText.text = this.upgradeCost.ToString();
    }
}

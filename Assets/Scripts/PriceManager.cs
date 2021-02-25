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
        if (WP.Money >= upgradeCost)
        {
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i].GetComponent<PriceManager>().upgradeCost *= 2;
            }
        }
    }
}

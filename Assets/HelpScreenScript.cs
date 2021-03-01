using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpScreenScript : MonoBehaviour
{
    public TMP_Text TStream;
    public TMP_Text TPC;
    public TMP_Text TSleep;
    public TMP_Text TDoor;
    public TMP_Text TGameStore;
    public TMP_Text TFood;
    public TMP_Text TInternet;
    public TMP_Text TGamingRig;
    public TMP_Text TSocialMediaMarketing;
    public TMP_Text TPay;



    public static bool TStreamBool;
    public static bool TPCBool;
    public static bool TSleepBool;
    public static bool TDoorBool;
    public static bool TGameStoreBool;
    public static bool TFoodBool;
    public static bool TInternetBool;
    public static bool TGamingRigBool;
    public static bool TSocialMediaMarketingBool;
    public static bool TPayBool;

    private void Start()
    {
        TStreamBool = false;
        TPCBool = false;
        TSleepBool = false;
        TDoorBool = false;
        TGameStoreBool = false;
        TFoodBool = false;
        TInternetBool = false;
        TGamingRigBool = false;
        TSocialMediaMarketingBool = false;
        TPayBool = false;
    }
    public void CheckProgress()
    {
        if (TStreamBool)
        {
            assignGreen(TStream);
        }
        if (TPCBool)
        {
            assignGreen(TPC);
        }
        if (TSleepBool)
        {
            assignGreen(TSleep);
        }
        if (TDoorBool)
        {
            assignGreen(TDoor);
        }
        if (TGameStoreBool)
        {
            assignGreen(TGameStore);
        }
        if (TFoodBool)
        {
            assignGreen(TFood);
        }
        if (TInternetBool)
        {
            assignGreen(TInternet);
        }
        if (TGamingRigBool)
        {
            assignGreen(TGamingRig);
        }
        if (TSocialMediaMarketingBool)
        {
            assignGreen(TSocialMediaMarketing);
        }
        if (TPayBool)
        {
            assignGreen(TPay);
        }
    }

    public void assignGreen(TMP_Text text)
    {
        text.color = new Color32(30, 255, 0, 255);
    }
}

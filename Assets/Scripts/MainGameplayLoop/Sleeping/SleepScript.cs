using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepScript : MonoBehaviour
{
    public TimerScript TS;
    public ResultScript RS;
    public PlayGame[] PG;
    public WORLDPARAMETERS WP;
    
    public void Sleep()
    {
        RS.ResetResults();
        //ResetGameTrendValues
        for(int i =0;i < PG.Length; i+=1 )
        {
            PG[i].ResetGameTrends();
        }
    }
}

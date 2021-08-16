using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public int GameTrend;
    public int GTMax;
    public int GTMin;
    public Image PopularityImage;

    void Start(){
        GameTrend = Random.Range(GTMin, GTMax);
        popularityIndicator();
    }

    public void ResetGameTrends(){
        GameTrend = Random.Range(GTMin, GTMax);
    }

    public void popularityIndicator(){
        if(this.GameTrend > 0 && this.GameTrend <40){
            PopularityImage.sprite = WP.popularityImages[0];
        }
        else if(this.GameTrend > 40 && this.GameTrend <60){
            PopularityImage.sprite = WP.popularityImages[1];
        }
        else if(this.GameTrend > 60 && this.GameTrend <90){
            PopularityImage.sprite = WP.popularityImages[2];
        }
        else if(this.GameTrend > 90){
            PopularityImage.sprite = WP.popularityImages[3];
        }
    }

}

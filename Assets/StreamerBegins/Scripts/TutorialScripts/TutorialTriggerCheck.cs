using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialTriggerCheck : MonoBehaviour
{
    public enum TutorialState{
    Start,
    PC,
    Door,
    Sleep,
    }
    public static TutorialState State;
    public static int TutorialProgress = 0;

    void Start() {
        State = TutorialState.Start;
    }
    public void ProgressTo1(){
        if(TutorialProgress ==0){
            TutorialProgress =1;
        }   
    }
    public void ProgressTo2(){
        if(TutorialProgress ==1){
            TutorialProgress =2;
        }   
    }

    public void ProgressTo3(){
        if(TutorialProgress ==2){
            TutorialProgress =3;
        }   
    }

    public void ProgressTo4(){
        if(TutorialProgress ==3){
            TutorialProgress =4;
        }   
    }

    public static void ProgressTo5(){
        if(TutorialProgress ==4){
                TutorialProgress =5;
        }   
    }

    public void ProgressTo6(){
        if(TutorialProgress ==5){
                TutorialProgress =6;
        }   
    }

    public void ProgressTo7(){
        if(TutorialProgress ==6){
                TutorialProgress =7;
        }   
    }
}



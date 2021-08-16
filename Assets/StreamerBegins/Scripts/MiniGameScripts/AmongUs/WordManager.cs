using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WordManager : MonoBehaviour
{
    public TMP_Text text;

    private string remainingWord = string.Empty;
    public string currentWord;
    public Image LeftTimer;
    public Image RightTimer;
    public static bool playerStarted;

    //public Timer timer;

    //public SceneMaster sceneMaster;
    void OnEnable()
    {
        playerStarted = false;
        text.SetText("Get Ready!");
        LeftTimer.fillAmount = 1;
        RightTimer.fillAmount =1;
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        text.color = Color.white;
        currentWord = WordGenerator.GetRandomWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        text.text = remainingWord;
    }

    private void Update()
    {
        //*********PROGRESS TO SPEND PHASE***************
        /*if (timer.Failed())
        {
            GameplayMaster.moneyValue += addMoney.moneyAmount;
            GameplayMaster.days++;
            sceneMaster.loadlevel(2);
        }*/
        if(StreamChosenGame.GOAHEAD){
            CheckInput();
            CheckIfComplete();
            if(LeftTimer.fillAmount >= 0 && RightTimer.fillAmount >= 0 && playerStarted){
                LeftTimer.fillAmount -= 0.2f *Time.unscaledDeltaTime;
                RightTimer.fillAmount -= 0.2f *Time.unscaledDeltaTime;
            }
        }


    }

    private void CheckIfComplete()
    {
        if (IsWordComplete())
        {
            SetCurrentWord();
            amongUsGameScript.amongUsPoints += 1;
           // timer.timerSpeed += 0.02f;
            ResetTimer();
        }
        else if(LeftTimer.fillAmount <= 0 && RightTimer.fillAmount <= 0)
        {
           // timer.failImage.fillAmount -= 0.2f;
            FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickErrorSound);   
            ResetTimer();
            SetCurrentWord();
        }
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length==1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            playerStarted = true;
            RemoveLetter();
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) ==0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        
        text.color = Color.red;
        SetRemainingWord(newString);
    }

    void ResetTimer(){
        LeftTimer.fillAmount = 1;
        RightTimer.fillAmount = 1;
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length ==0;
    }

}

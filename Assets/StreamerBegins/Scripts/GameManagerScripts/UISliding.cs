﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public enum ActiveMenu{
    Upgrade,
    Results,
    Game,
    Bills,
    GameStore,
    FoodStore,
    Help,
    GameOver,
    Restart,
    PartTime,
    GameResult
}
public class UISliding : MonoBehaviour
{
    public ActiveMenu activeMenu;
    public UnityEvent OpenMenu;
    public UnityEvent CloseMenu;
    public RectTransform UpgradeScreen;
    public RectTransform ResultsScreen;
    public RectTransform GameScreen;
    public RectTransform BillsScreen;
    public RectTransform GameStoreScreen;
    public RectTransform FoodStoreScreen;
    public RectTransform HelpScreen;
    public RectTransform GOScreen;
    public RectTransform RestartScreen;
    public RectTransform PartTimeScreen;
    public RectTransform GameResultScreen;

    public bool UIActive;
    public bool GameScreenActive;

    public GameObject DoorUI;
    public GameObject gameStoreButton;
    public GameObject foodStoreButton;
    public GameObject partTimeButton;

    public GameObject CloseUpgradeScreenButton;
    public GameObject OpenUpgradeScreenButton;

    public Slider DurationSlider;

    public Camera GameplayCamera;
    public Camera RoomCamera;
    public GameObject FaceCam;

    //public GameObject StreamTitleBar;
    bool closeDelay;
    bool delayCoroutineRunning;
    public UnityEvent ChangeUpgradeSprite;

    public SoundManager SoundManager;
    void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }


    void Start(){
        closeDelay = false;
        if(DialogueScript.TextActive) return;
        UIActive = true;
    }

    private void Update()
    {
        if(RoomCamera.transform.position.x >= -4f){
            ShowWall();
        }
        else{
            HideWall();
        }
    }
    public void OpenGameResultScreen(){
        UIActive = true;
        GameResultScreen.DOAnchorPos(Vector2.zero, 0.25f);
        OpenMenu.Invoke();
        activeMenu = ActiveMenu.GameResult;
    }
    public void CloseGameResultScreen(){
        UIActive = false;
        GameResultScreen.DOAnchorPos(new Vector2(0, 974), 0.25f);
        CloseMenu.Invoke();
    }
    public void OpenUpgradeScreen()
    {
        if(!StreamChosenGame.amIStreaming&& UIActive == false&& !GetInBed.isAsleep)
        {
            ChangeUpgradeSprite.Invoke();
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            CloseUpgradeScreenButton.SetActive(true);
            OpenUpgradeScreenButton.SetActive(false);
            UIActive = true;
            UpgradeScreen.DOAnchorPos(new Vector2(0, 472f), 0.25f);
            OpenMenu.Invoke();
            activeMenu = ActiveMenu.Upgrade;
        }
    }

    public void CloseUpgradeScreen()
    {
        if (!StreamChosenGame.amIStreaming)
        {
            SoundManager.PlaySound(SoundManager.closeWindowSound);   
            CloseUpgradeScreenButton.SetActive(false);
            OpenUpgradeScreenButton.SetActive(true);
            UIActive = false;
            UpgradeScreen.DOAnchorPos(new Vector2(0, -528f), 0.25f);
            CloseMenu.Invoke();
        }
    }

    public void OpenResultsScreen()
    {
        UIActive = true;
        ResultsScreen.DOAnchorPos(Vector2.zero, 0.25f);
        OpenMenu.Invoke();
        activeMenu = ActiveMenu.Results;
    }

    public void CloseResultsScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        ResultsScreen.DOAnchorPos(new Vector2(0, 974), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenGameScreen()
    {
        SoundManager.PlaySound(SoundManager.clickSound);   
        HelpScreenScript.TStreamBool = true;
       // DurationSlider.value = 0f;
        GameScreenActive = true;
        UIActive = true;
        GameScreen.DOAnchorPos(Vector2.zero, 0.25f);
        activeMenu = ActiveMenu.Game;
        OpenMenu.Invoke();
        
    }

    public void CloseGameScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        GameScreenActive = false;
        UIActive = false;
        GameScreen.DOAnchorPos(new Vector2(-1864, 0), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenBillsScreen()
    {
            UIActive = true;
            BillsScreen.DOAnchorPos(Vector2.zero, 0.25f);
            OpenMenu.Invoke();
            activeMenu = ActiveMenu.Bills;
    }

    public void CloseBillsScreen()
    {  
        if(ResultsScreen.anchoredPosition == Vector2.zero){
            BillsScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
            CloseMenu.Invoke();
        }
        else{
            UIActive = false;
            BillsScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
            CloseMenu.Invoke();
        }

    }

    public void OpenGameStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        GameStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        DoorUI.SetActive(false);
        OpenMenu.Invoke();
        activeMenu = ActiveMenu.GameStore;
    }

    public void CloseGamesStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        GameStoreScreen.DOAnchorPos(new Vector2(1831, 0), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenFoodStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        FoodStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        DoorUI.SetActive(false);
        OpenMenu.Invoke();
        activeMenu = ActiveMenu.FoodStore;
    }

    public void CloseFoodStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        FoodStoreScreen.DOAnchorPos(new Vector2(1831, 0), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenHelpScreen()
    {
        if (!StreamChosenGame.amIStreaming && UIActive == false && !GetInBed.isAsleep)
        {
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            UIActive = true;
            HelpScreen.DOAnchorPos(Vector2.zero, 0.25f);
            OpenMenu.Invoke();
            activeMenu = ActiveMenu.Help;
        }
    }

    public void CloseHelpScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        HelpScreen.DOAnchorPos(new Vector2(1521f, -924f), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenGOScreen()
    {
        SoundManager.PlaySound(SoundManager.miniGameLoseSound);   
            UIActive = true;
            GOScreen.DOAnchorPos(Vector2.zero, 0.25f);
            OpenMenu.Invoke();
            activeMenu = ActiveMenu.GameOver;
    }

    public void CloseGOScreen()
    {
        UIActive = false;
        GOScreen.DOAnchorPos(new Vector2(2426f, 0f), 0.25f);
        CloseMenu.Invoke();
    }

    public void OpenRestartScreen()
    {
        if (!StreamChosenGame.amIStreaming && UIActive == false&& !GetInBed.isAsleep)
        {
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            UIActive = true;
            RestartScreen.DOAnchorPos(Vector2.zero, 0.25f);
            OpenMenu.Invoke();
            activeMenu = ActiveMenu.Restart;
        }


    }

    public void CloseRestartScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        RestartScreen.DOAnchorPos(new Vector2(2426f, 0f), 0.25f);
        CloseMenu.Invoke();
    }
    
    public void OpenPartTimeScreen(){
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        PartTimeScreen.DOAnchorPos(new Vector2(34f, 9.2f), 0.25f);
        DoorUI.SetActive(false);
        OpenMenu.Invoke();
        activeMenu = ActiveMenu.PartTime;
    }

    public void ClosePartTimeScreen()
    { 
        if(PartTimeScript.isWorking == true){
            SoundManager.PlaySound(SoundManager.clickSound);
        }
        else if(PartTimeScript.isWorking == false){
            SoundManager.PlaySound(SoundManager.closeWindowSound);
        }
        UIActive = false;
        PartTimeScreen.DOAnchorPos(new Vector2(1831, 0), 0.25f);
        CloseMenu.Invoke();
    }


    public void StreamPerspective(){
        RoomCamera.transform.DOMove(new Vector3(-3.461f,3.461f,-6.122f), 2);
        RoomCamera.transform.DORotate(new Vector3(0,0,0), 2);
    }

    public void RoomPerspective(){
        RoomCamera.transform.DOMove(new Vector3(-15f,4.56f,0.59f), 2);
        RoomCamera.transform.DORotate(new Vector3(0,85,0), 2);
    }

  private void ShowWall() {
     RoomCamera.cullingMask |= 1 << LayerMask.NameToLayer("RandomWall");
 }
  private void HideWall() {
     RoomCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("RandomWall"));
 }

   public void RescaleFaceCamera(){
       FaceCam.transform.DOScale(new Vector3(50.46221f,219.3284f,31.46498f), 1);
       FaceCam.transform.DOLocalMove(new Vector3(-712f,-291.3f,-10098.91f), 1);
   }

    public void RescaleFaceCameraBase(){
       FaceCam.transform.DOScale(new Vector3(190.1007f,219.3283f,110.0575f), 1);
       FaceCam.transform.DOLocalMove(new Vector3(-10.73804f,-9.193085f,-10098.91f), 1);
   }

   public void RunDelayCoroutine(){
       if(!delayCoroutineRunning){
        StartCoroutine("DelayCloseButton");
       }

   }

   public IEnumerator DelayCloseButton(){
       delayCoroutineRunning = true;
       yield return new WaitForSeconds(0.5f);
       closeDelay = true; 
       delayCoroutineRunning = false;
   }

   public void changeCloseDelay(bool value){
       closeDelay = value;
   }

   public void CloseActiveMenu(){
       if(closeDelay){
        switch(activeMenu){
            case ActiveMenu.Upgrade:
            CloseUpgradeScreen();
            break;
            case ActiveMenu.Bills:
            CloseBillsScreen();
            break;
            case ActiveMenu.FoodStore:
            CloseFoodStoreScreen();
            break;
            case ActiveMenu.Game:
            CloseGameScreen();
            break;
            case ActiveMenu.GameOver:
            CloseGOScreen();
            break;
            case ActiveMenu.GameResult:
            //CloseGameResultScreen();
            break;
            case ActiveMenu.GameStore:
            CloseGamesStoreScreen();
            break;
            case ActiveMenu.Help:
            CloseHelpScreen();
            break;
            case ActiveMenu.PartTime:
            ClosePartTimeScreen();
            break;
            case ActiveMenu.Restart:
            CloseRestartScreen();
            break;
            case ActiveMenu.Results:
            CloseResultsScreen();
            break;
        }
       }

   }
}

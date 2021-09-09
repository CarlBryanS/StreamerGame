using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UISliding : MonoBehaviour
{

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

    public SoundManager SoundManager;
        void Awake(){
        SoundManager = FindObjectOfType<SoundManager>();
    }


    void Start(){
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
    }
    public void CloseGameResultScreen(){
        UIActive = false;
        GameResultScreen.DOAnchorPos(new Vector2(0, 974), 0.25f);
    }
    public void OpenUpgradeScreen()
    {
        if(!StreamChosenGame.amIStreaming&& UIActive == false&& !GetInBed.isAsleep)
        {
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            CloseUpgradeScreenButton.SetActive(true);
            OpenUpgradeScreenButton.SetActive(false);
            UIActive = true;
            UpgradeScreen.DOAnchorPos(new Vector2(0, 472f), 0.25f);
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
            UpgradeScreen.DOAnchorPos(new Vector2(0, -362f), 0.25f);
        }
    }

    public void OpenResultsScreen()
    {
        UIActive = true;
        ResultsScreen.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CloseResultsScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        ResultsScreen.DOAnchorPos(new Vector2(0, 974), 0.25f);
    }

    public void OpenGameScreen()
    {
        SoundManager.PlaySound(SoundManager.clickSound);   
        HelpScreenScript.TStreamBool = true;
        DurationSlider.value = 0f;
        GameScreenActive = true;
        UIActive = true;
        GameScreen.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CloseGameScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        GameScreenActive = false;
        UIActive = false;
        GameScreen.DOAnchorPos(new Vector2(-1566, 0), 0.25f);
        
    }

    public void OpenBillsScreen()
    {
        UIActive = true;
        BillsScreen.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CloseBillsScreen()
    {  
        UIActive = false;
        BillsScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
    }

    public void OpenGameStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        GameStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        DoorUI.SetActive(false);
       /* gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
        partTimeButton.SetActive(false);*/
    }

    public void CloseGamesStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        GameStoreScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
    }

    public void OpenFoodStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        FoodStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        DoorUI.SetActive(false);
       /* gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
        partTimeButton.SetActive(false);*/
    }

    public void CloseFoodStoreScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        FoodStoreScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
    }

    public void OpenHelpScreen()
    {
        if (!StreamChosenGame.amIStreaming && UIActive == false && !GetInBed.isAsleep)
        {
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            UIActive = true;
            HelpScreen.DOAnchorPos(Vector2.zero, 0.25f);
        }
    }

    public void CloseHelpScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        HelpScreen.DOAnchorPos(new Vector2(1521f, -924f), 0.25f);
    }

    public void OpenGOScreen()
    {
        SoundManager.PlaySound(SoundManager.miniGameLoseSound);   
            UIActive = true;
            GOScreen.DOAnchorPos(Vector2.zero, 0.25f);
        
    }

    public void CloseGOScreen()
    {
        UIActive = false;
        GOScreen.DOAnchorPos(new Vector2(2426f, 0f), 0.25f);
    }

    public void OpenRestartScreen()
    {
        if (!StreamChosenGame.amIStreaming && UIActive == false&& !GetInBed.isAsleep)
        {
            SoundManager.PlaySound(SoundManager.openWindowSound);   
            UIActive = true;
            RestartScreen.DOAnchorPos(Vector2.zero, 0.25f);
        }


    }

    public void CloseRestartScreen()
    {
        SoundManager.PlaySound(SoundManager.closeWindowSound);   
        UIActive = false;
        RestartScreen.DOAnchorPos(new Vector2(2426f, 0f), 0.25f);
    }
    
    public void OpenPartTimeScreen(){
        SoundManager.PlaySound(SoundManager.openWindowSound);   
        UIActive = true;
        PartTimeScreen.DOAnchorPos(new Vector2(109f, 9.2f), 0.25f);
        DoorUI.SetActive(false);
       /* gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
        partTimeButton.SetActive(false); */
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
        PartTimeScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
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
}

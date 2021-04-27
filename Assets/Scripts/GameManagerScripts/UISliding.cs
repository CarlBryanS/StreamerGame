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
    public RectTransform DonationScreen;

    public bool UIActive;
    public bool DonationIsActive;
    public bool GameScreenActive;

    public GameObject gameStoreButton;
    public GameObject foodStoreButton;

    public GameObject CloseUpgradeScreenButton;
    public GameObject OpenUpgradeScreenButton;

    public Slider DurationSlider;

    public Camera GameplayCamera;
    public Camera RoomCamera;
    public GameObject FaceCam;

    private void Update()
    {
        if(RoomCamera.transform.position.x >= -4f){
            ShowWall();
        }
        else{
            HideWall();
        }
    }
    public void OpenUpgradeScreen()
    {
        if(!PlayGame.amIStreaming && UIActive == false)
        {
            CloseUpgradeScreenButton.SetActive(true);
            OpenUpgradeScreenButton.SetActive(false);
            UIActive = true;
            UpgradeScreen.DOAnchorPos(new Vector2(0, 472f), 0.25f);
        }
    }

    public void CloseUpgradeScreen()
    {
        if (!PlayGame.amIStreaming)
        {
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
        UIActive = false;
        ResultsScreen.DOAnchorPos(new Vector2(0, 974), 0.25f);
    }

    public void OpenGameScreen()
    {
        HelpScreenScript.TStreamBool = true;
        DurationSlider.value = 0f;
        GameScreenActive = true;
        UIActive = true;
        GameScreen.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CloseGameScreen()
    {
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
        UIActive = true;
        GameStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
    }

    public void CloseGamesStoreScreen()
    {
        UIActive = false;
        GameStoreScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
    }

    public void OpenFoodStoreScreen()
    {
        UIActive = true;
        FoodStoreScreen.DOAnchorPos(Vector2.zero, 0.25f);
        gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
    }

    public void CloseFoodStoreScreen()
    {
        UIActive = false;
        FoodStoreScreen.DOAnchorPos(new Vector2(1566, 0), 0.25f);
    }

    public void OpenHelpScreen()
    {
        if (!PlayGame.amIStreaming && UIActive == false)
        {
            UIActive = true;
            HelpScreen.DOAnchorPos(Vector2.zero, 0.25f);
        }
    }

    public void CloseHelpScreen()
    {
        UIActive = false;
        HelpScreen.DOAnchorPos(new Vector2(1521f, -924f), 0.25f);
    }

    public void OpenGOScreen()
    {

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
        if (!PlayGame.amIStreaming && UIActive == false)
        {
            UIActive = true;
            RestartScreen.DOAnchorPos(Vector2.zero, 0.25f);
        }


    }

    public void CloseRestartScreen()
    {
        UIActive = false;
        RestartScreen.DOAnchorPos(new Vector2(2426f, 0f), 0.25f);
    }

    public void OpenDonations()
    {
        DonationIsActive = true;
        DonationScreen.DOAnchorPos(new Vector2(1, -4), 0.25f);     
    }

    public void CloseDonations()
    {
        if(DonationIsActive == true){
            DonationScreen.DOAnchorPos(new Vector2(1f, 584f), 0.25f);      
            DonationIsActive = false;
        }

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
       FaceCam.transform.DOScale(new Vector3(0.06932702f,0.2637316f,0.04150333f), 1);
       FaceCam.transform.DOLocalMove(new Vector3(-0.92f,-0.578f,-1.2f), 1);
   }

    public void RescaleFaceCameraBase(){
       FaceCam.transform.DOScale(new Vector3(0.2577544f,0.9805408f,0.1543073f), 1);
       FaceCam.transform.DOLocalMove(new Vector3(0.02f,-0.03f,-1.2f), 1);
   }
}

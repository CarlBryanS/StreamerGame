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

    public bool UIActive;
    public bool GameScreenActive;

    public GameObject gameStoreButton;
    public GameObject foodStoreButton;

    public GameObject CloseUpgradeScreenButton;
    public GameObject OpenUpgradeScreenButton;

    public Slider DurationSlider;

    private void Update()
    {
    }
    public void OpenUpgradeScreen()
    {
        if(!PlayGame.amIStreaming)
        {
            CloseUpgradeScreenButton.SetActive(true);
            OpenUpgradeScreenButton.SetActive(false);
            UIActive = true;
            UpgradeScreen.DOAnchorPos(new Vector2(0, 0), 0.25f);
        }
    }

    public void CloseUpgradeScreen()
    {
        if (!PlayGame.amIStreaming)
        {
            CloseUpgradeScreenButton.SetActive(false);
            OpenUpgradeScreenButton.SetActive(true);
            UIActive = false;
            UpgradeScreen.DOAnchorPos(new Vector2(0, -910), 0.25f);
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

}

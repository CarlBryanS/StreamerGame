﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOutside : MonoBehaviour
{
    public UISliding UI;

    public GameObject DoorUI;

    public GameObject gameStoreButton;
    public GameObject foodStoreButton;
    public GameObject partTimeButton;
    private void OnMouseEnter()
    {
        if (!StreamChosenGame.amIStreaming && !UI.UIActive && !PartTimeScript.isWorking && !GetInBed.isAsleep)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(0.8496809f,6.734204f,7f);
            this.GetComponent<BoxCollider>().center = new Vector3(-1.825011f, 2.046926f, -1.640409f);
            DoorUI.SetActive(true);
           // partTimeButton.SetActive(true);
          //  gameStoreButton.SetActive(true);
           // foodStoreButton.SetActive(true);
            HelpScreenScript.TDoorBool = true;
        }
    }

    private void OnMouseExit()
    {
        this.GetComponent<BoxCollider>().size = new Vector3(0.8496804f, 4.476605f, 2.774182f);
        this.GetComponent<BoxCollider>().center = new Vector3(-1.825011f, 0.9181263f, -1.509893f);
        DoorUI.SetActive(false);

        //gameStoreButton.SetActive(false);
       // foodStoreButton.SetActive(false);
       // partTimeButton.SetActive(false);
    }

}

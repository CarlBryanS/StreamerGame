using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOutside : MonoBehaviour
{
    public UISliding UI;

    public GameObject gameStoreButton;
    public GameObject foodStoreButton;
    private void OnMouseEnter()
    {
        if (!PlayGame.amIStreaming && !UI.UIActive)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(0.8496804f, 6.774739f, 4.823626f);
            this.GetComponent<BoxCollider>().center = new Vector3(-1.825011f, 2.067194f, -1.398365f);
            gameStoreButton.SetActive(true);
            foodStoreButton.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        this.GetComponent<BoxCollider>().size = new Vector3(0.8496804f, 4.476605f, 2.774182f);
        this.GetComponent<BoxCollider>().center = new Vector3(-1.825011f, 0.9181263f, -1.509893f);

        gameStoreButton.SetActive(false);
        foodStoreButton.SetActive(false);
    }

}

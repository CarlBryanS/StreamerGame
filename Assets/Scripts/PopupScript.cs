using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    public GameObject icon;

    private void Awake()
    {
    }
    
   /*   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillWall")
        {
            Destroy(this.gameObject);
        }
    }
  void OnMouseDown()
    {
        GameObject WP = GameObject.Find("GAMEMANAGER");
        WORLDPARAMETERS WPScript = WP.GetComponent<WORLDPARAMETERS>();

        GameObject RS = GameObject.Find("Results");
        ResultScript RSScript = RS.GetComponent<ResultScript>();

        switch (this.gameObject.name)
        {
            case "ChatBubbleObject(Clone)":
                RSScript.FansGainedValue += 1;
                WPScript.Fans += 1;
                FindObjectOfType<SoundManager>().playChatSound();
                break;
            case "TenPesoObject(Clone)":
                RSScript.MoneyGainedValue += 10;
                WPScript.Money += 10;
                FindObjectOfType<SoundManager>().playCoinSound();
                break;
        }
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        icon.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        this.transform.position += -transform.up * Time.deltaTime;
    }*/
}

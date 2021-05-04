using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTimer : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public UISliding UI;
    
    Image bar;
    int amountDonated;
    bool Enabled;
    public float timerSpeed;

    void OnEnable(){
        amountDonated = Random.Range(1,20);
         Enabled = true;
    }
    void OnDisable(){
        Enabled = false;
    }
    void Start(){
        bar = GetComponent<Image>();
    }
    void Update(){
        
       if(Enabled == true && PlayGame.amIStreaming)
       {
            StartTimer();
       }
    }

    // Start is called before the first frame update
    public void StartTimer()
    {
        bar.fillAmount -= Time.unscaledDeltaTime/timerSpeed;
    }
}

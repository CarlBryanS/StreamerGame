using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class DonationScript : MonoBehaviour
{


    public WORLDPARAMETERS WP;
    public ChatScript CS ;
    public PersonalityMessagesScript PMS;
    Chatter currentDonator;


    public TMP_Text DonationText;

    public string RandomMessage;
    public int RandomAmount;

    bool StartFadeOut;
    bool StartFadeIn;

    CanvasGroup DonationGroup;
    

    // Start is called before the first frame update
    void OnEnable()
    {       
    
    
       currentDonator =CS.ActiveChatters[Random.Range(0,CS.ActiveChatters.Count)];
       Debug.Log(currentDonator.chatterName);

       switch(currentDonator.chatterWealth){
           case "Poor":
            RandomAmount = Random.Range(1,10);
            break;
           case "Rich":
            RandomAmount = Random.Range(10,20);
            break; 
       } 

       switch(currentDonator.chatterPersonality){
           case "Kind":
            RandomMessage = PMS.KindDonations[Random.Range(0,PMS.KindDonations.Length)];
            break;
           case "Toxic":
            RandomMessage = PMS.ToxicDonations[Random.Range(0,PMS.ToxicDonations.Length)];
            break; 
       }

       WP.Money += RandomAmount;
       DonationText.SetText(currentDonator.chatterName+ " has donated " + RandomAmount + " Pesos." + "\n" + "\n" + RandomMessage); 
       StartCoroutine("Donation");      
    }

    void Start(){
        DonationGroup = GetComponent<CanvasGroup>(); 
    }
    // Update is called once per frame
    void Update()
    {   
    if(StartFadeIn){
        DonationGroup.alpha += Time.unscaledDeltaTime/1.2f;
    }
    if(StartFadeOut){
        DonationGroup.alpha -= Time.unscaledDeltaTime/1.2f;
    }
    }

    IEnumerator Donation()
    {
        yield return new WaitForSeconds(1);
        StartFadeIn = true;
        yield return new WaitUntil(() =>DonationGroup.alpha == 1);
        StartFadeIn= false;
        yield return new WaitForSeconds(4);
        StartFadeOut = true;
        yield return new WaitUntil(() =>DonationGroup.alpha == 0);
        StartFadeOut = false;
        this.gameObject.SetActive(false);
    }
}

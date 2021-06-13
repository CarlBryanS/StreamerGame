using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public ChatterGenerator CG;
    public ResultScript RS;
    public PersonalityMessagesScript PMS;
    public List<Chatter> ActiveChatters = new List<Chatter>();
    string ChatString;
    string RandomMessage;
    public TMP_Text ChatBox;
    public GameObject Donation;

    public bool crRunning;
 
  
    //int testLimit = 5;
    // Start is called before the first frame update
    void OnEnable(){

    }

    void Start(){
        crRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(StreamChosenGame.amIStreaming){
            /*foreach(Chatter x in ActiveChatters){
                Debug.Log(x.chatterName + " " + ActiveChatters.IndexOf(x));
            }*/
            ChatBox.SetText(ChatString);

            if(WP.Viewers/2> ActiveChatters.Count && ActiveChatters.Count <= CG.Chatters.Count){
            AddActiveChatter(CG.Chatters[Random.Range(0, CG.Chatters.Count)]);
            }

            if(crRunning == false && StreamChosenGame.amIStreaming){
                StartCoroutine("StartChat");
            }
        }
    }

    void AddActiveChatter(Chatter chatter){
        if(!ActiveChatters.Contains(chatter)){
            ActiveChatters.Add(chatter);
        }
    }

    public void ClearActiveChatters(){
        ChatString = "";
        ActiveChatters.Clear();
    }


    public void AddChatMessages(Chatter currentChatter)
    {
        currentChatter = ActiveChatters[Random.Range(0, ActiveChatters.Count)];

        switch(currentChatter.chatterPersonality){
           case "Kind":
            RandomMessage = PMS.KindMessages[Random.Range(0,PMS.KindMessages.Length)];
            break;
           case "Toxic":
            RandomMessage = PMS.ToxicMessages[Random.Range(0,PMS.ToxicMessages.Length)];
            break; 
        }

        ChatString += (currentChatter.chatterName + ": " + RandomMessage + "\n");
    }

     IEnumerator StartChat()
    {  
     crRunning = true;
     yield return new WaitForSeconds(3);
     while(true){
         if(ActiveChatters.Count != 0){
            AddChatMessages(ActiveChatters[Random.Range(0, ActiveChatters.Count)]);
         }

         yield return new WaitForSeconds(4);
         if(!StreamChosenGame.amIStreaming || miniGameState.State == miniGameState.mgState.paused){
            break;
         }

     }
    yield return crRunning = false;
    }

    public void DonationCheck(){
        if(ActiveGame.selectedGame == "amongUs"){
            if(WordManager.playerStarted){
                if(!Donation.activeSelf){
            foreach(Chatter x in ActiveChatters){
                if(GachaRoll() <11){
                    Donation.SetActive(true);
                }
            }
        }
            }
        }
        else{
        if(!Donation.activeSelf){
            foreach(Chatter x in ActiveChatters){
                if(GachaRoll() <11){
                    Donation.SetActive(true);
                }
            }
        }
        }

    }

    public int GachaRoll(){
        int roll = Random.Range(0,100);
        return roll;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    public ChatterGenerator CG;
    public PersonalityMessagesScript PMS;
    public List<Chatter> ActiveChatters = new List<Chatter>();
    Chatter ChatterToBeAdded;

    string ChatString;
    string RandomMessage;
    public TMP_Text ChatBox;

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
        ChatBox.SetText(ChatString);

        if(WP.Viewers> ActiveChatters.Count && ActiveChatters.Count <= CG.Chatters.Count){
           AddActiveChatter(CG.Chatters[Random.Range(0, CG.Chatters.Count)]);
        }

        if(crRunning == false && PlayGame.amIStreaming){
            StartCoroutine("StartChat");
        }
    }

    void AddActiveChatter(Chatter chatter){
        if(!ActiveChatters.Contains(chatter)){
            ActiveChatters.Add(chatter);
        }
    }

    public void ClearActiveChatters(){
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
         Debug.Log("adding messages");
         AddChatMessages(CG.Chatters[Random.Range(0, CG.Chatters.Count)]);
         yield return new WaitForSeconds(4);
         if(PlayGame.amIStreaming == false){
            break;
         }

     }
    yield return crRunning = false;
 }
}

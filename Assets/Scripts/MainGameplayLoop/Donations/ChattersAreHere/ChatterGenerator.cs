using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChatterGenerator : MonoBehaviour
{
    //Name is here
    public string[] NameSegment1;
    public string[] NameSegment2;
    public string RandomName;

    //Personality
    public string[] Personality;

    //Wealth
    public string[] Wealth;

    //Is Banned?
    public bool isBanned;

    public string tempName;

    public bool guyIsHere;

   [SerializeField]
   public List<Chatter> Chatters = new List<Chatter>();

    void Start(){
        Chatters.Add(new Chatter(tempName, Personality[Random.Range(0, Personality.Length)], Wealth[Random.Range(0, Wealth.Length)], false)); 
    }

    void Update(){
        /*foreach(Chatter x in Chatters) {
            Debug.Log(x.chatterName.ToString() + " "+x.chatterPersonality.ToString() +" "+ x.chatterWealth.ToString() + " "+x.chatterIsBanned.ToString() + " " + Chatters.IndexOf(x));
          }*/
        foreach(Chatter x in Chatters.ToList()) {
            Debug.Log(x.chatterName.ToString() + " " + Chatters.IndexOf(x));
          }

        AddUniqueChatter();
    }

    public string GenerateName(){
        RandomName = ReturnFromList(NameSegment1) + ReturnFromList(NameSegment2);
        return RandomName;
    }

    public string ReturnFromList(string[] list){
        return list[Random.Range(0, list.Length)];
    } 

    public void GenerateChatter(){
        tempName=RandomName;
        Chatters.Add(new Chatter(tempName, Personality[Random.Range(0, Personality.Length)], Wealth[Random.Range(0, Wealth.Length)], false));  
    }

    public void AddUniqueChatter(){
        GenerateName();
        foreach(Chatter x in Chatters.ToList()) {
            if((x.chatterName.ToString() != RandomName)){
                Debug.Log("wow");
                guyIsHere=false;
                if(guyIsHere == false){
                    GenerateChatter();
                 }
            }
            else{
                guyIsHere = true;
            }
        }


    }
}

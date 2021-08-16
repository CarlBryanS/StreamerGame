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

    public bool guyIsHere;

   [SerializeField]
   public List<Chatter> Chatters = new List<Chatter>();

    void Start(){    
         GenerateList();
    }

    void Update(){
       // foreach(Chatter x in Chatters) {
         //  Debug.Log(x.chatterName.ToString() + " "+x.chatterPersonality.ToString() +" "+ x.chatterWealth.ToString() + " "+x.chatterIsBanned.ToString() + " " + Chatters.IndexOf(x));
        // }
     /*   if(Chatters.Count < 9){
            AddUniqueChatter();
        }
        else{
            Debug.Log("wow");
            this.gameObject.SetActive(false);
        }*/
   
    }

    public string GenerateName(){
        RandomName = ReturnFromList(NameSegment1) + ReturnFromList(NameSegment2);
        return RandomName;
    }

    public string ReturnFromList(string[] list){
        return list[Random.Range(0, list.Length)];
    } 

    public void GenerateChatter(string name){
        Chatters.Add(new Chatter(name, Personality[Random.Range(0, Personality.Length)], Wealth[Random.Range(0, Wealth.Length)], false));  
        guyIsHere= false;
    }

    public void AddUniqueChatter(){
        if(Chatters.Count >0){
                GenerateName();          
                foreach(Chatter x in Chatters.ToList()) {  
                    if((x.chatterName.ToString() == RandomName)){
                        guyIsHere = true;
                    }
                }

                if(guyIsHere ==false){
                    GenerateChatter(RandomName);
                }
                else{
                    guyIsHere =false;
                }

        }
        else{
            GenerateChatter(GenerateName());
        }

    }
    public void GenerateList(){
        while(Chatters.Count<9){
            AddUniqueChatter();
        }
    }
    
}

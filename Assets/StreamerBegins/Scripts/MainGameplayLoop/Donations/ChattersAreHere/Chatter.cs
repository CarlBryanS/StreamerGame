using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatter
{
    public string chatterName;
    public string chatterWealth;
    public string chatterPersonality;
    public bool chatterIsBanned;

     public Chatter(string name, string personality, string wealth, bool isBanned){
        this.chatterName = name;
        this.chatterWealth = wealth;
        this.chatterPersonality = personality;
        this.chatterIsBanned = isBanned;
    }
}



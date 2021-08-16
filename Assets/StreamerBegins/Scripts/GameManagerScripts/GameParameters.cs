using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StreamerBegins{
    public class GameParameters : MonoBehaviour
    {      
        public float Energy;
        public float Health;
        public int Money;
        public int Fans;
        public int Viewers;

        private static GameParameters instance;
        // Start is called before the first frame update
        public static GameParameters Instance 
        { 
            get { return instance; } 
        }    

        private void Awake() 
        { 
            if (instance != null && instance != this) 
            { 
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
    }
}


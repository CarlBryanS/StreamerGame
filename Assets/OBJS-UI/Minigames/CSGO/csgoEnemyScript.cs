using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csgoEnemyScript : MonoBehaviour
{
    public int Health;
    public Sprite idleSprite;
    public Sprite hitSprite;
    float timeAlive;
    Animator anim;
    SpriteRenderer sr;
    public GameObject parent;
    void Start(){
        
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>(); 
    }

    void OnEnable(){
        timeAlive = (Random.Range(6,10));
    }
    void OnDisable(){
        Destroy(this.gameObject);
    }
    void Update(){
        if(timeAlive <=0){
           Destroy(this.gameObject);
        }
        timeAlive -= Time.unscaledDeltaTime;
    }
    
    void OnMouseDown(){
        if(Health ==1){
            CSGOGameScript.csgoPoints +=1;
            Destroy(this.gameObject);
        }
        else{
        anim.SetTrigger("gotHit");
        Health -=1;   
        }     
    }
}

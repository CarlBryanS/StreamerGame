using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcEnemyScript : MonoBehaviour
{
    public float speed;
    public float health;
    SpriteRenderer sprite;
     Animator anim;
    // Start is called before the first frame update
    void OnEnable(){       
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().ZombieSpawnSound);    
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void OnDisable(){
        Destroy(this.gameObject);
    }

   void Update()
    {
        transform.Translate((transform.right * -3 * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag =="Bullet"){
           
            anim.SetTrigger("gotHit");
            health -=1;
            if(health<=0){
                FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().ZombieDeathSound);    
                mcGameScript.mcPoints+=1;
                Destroy(this.gameObject);
            }
        }
        else if(coll.gameObject.tag =="Player"){
            mcGameScript.mcGotHit = true;
        }
    }

}

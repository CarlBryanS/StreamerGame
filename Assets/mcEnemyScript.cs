using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcEnemyScript : MonoBehaviour
{
    public float speed;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
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
            health -=1;
            if(health<=0){
                mcGameScript.mcPoints+=1;
                Destroy(this.gameObject);
            }
        }
        else if(coll.gameObject.tag =="Player"){
            mcGameScript.mcGotHit = true;
        }
    }
}

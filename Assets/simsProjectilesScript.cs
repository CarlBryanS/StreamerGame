using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simsProjectilesScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void OnEnable()
    {
        speed = Random.Range(-2,-4);
    }
    void OnDisable(){
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.up * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(this.gameObject.tag == "simsMoney" &&(coll.gameObject.tag == "Player")){
            simsGameScript.simsPoints += 1;
            Destroy(this.gameObject);
        }
        else if(this.gameObject.tag == "simsSad" &&(coll.gameObject.tag == "Player")){
            simsGameScript.simsHealth -=1;
            Destroy(this.gameObject);
        }
        else if(coll.gameObject.tag == "KillWall"){
            Destroy(this.gameObject);
        }
    }
}

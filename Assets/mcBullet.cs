using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcBullet : MonoBehaviour
{
    void OnEnable()
    {
    }
    void OnDisable(){
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.right * 5 * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag =="KillWall" || coll.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
        }
    }
}

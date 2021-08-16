using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcFireScript : MonoBehaviour
{
    public GameObject[] Spawnables;
    public float xDimensions;
    public float yDimensions;
    public float zDimensions;
    public GameObject parent;
    public void Fire(){
        int randomSpawn = Random.Range(0, Spawnables.Length);
        Vector3 whereToSpawn = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject Bullet = Instantiate(Spawnables[randomSpawn], whereToSpawn, transform.rotation) as GameObject;
        Bullet.transform.SetParent(parent.transform);   
        Bullet.transform.localScale = new Vector3(xDimensions, yDimensions, zDimensions); 
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
        Fire();    
        }
    }
}

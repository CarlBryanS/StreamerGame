using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcSpawnerScript : MonoBehaviour
{
    public GameObject[] Spawnables;
    public float xDimensions;
    public float yDimensions;
    public float zDimensions;
    public GameObject parent;
    float timer;
    // Start is called before the first frame update
    void OnEnable(){
                timer = Random.Range(2, 5);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (StreamChosenGame.GOAHEAD)
        {
           timer -= Time.unscaledDeltaTime; 
           if(timer <= 0 ){
               Spawn();
           }  
        }
    }
    
    void Spawn(){
        timer = Random.Range(1, 3);
        //float randomLocation = Random.Range(this.transform.position.x, 31.11f);
        int randomSpawn = Random.Range(0, Spawnables.Length);
        Vector3 whereToSpawn = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject mcEnemies = Instantiate(Spawnables[randomSpawn], whereToSpawn, transform.rotation) as GameObject;
        mcEnemies.transform.SetParent(parent.transform);
        if(this.tag == "simsSpawner" &&randomSpawn == 1){
            xDimensions = 2.250732f;
            yDimensions =2.250732f;
            zDimensions =22.250732f;    
        }
        else if(this.tag == "simsSpawner"){
            xDimensions =2.250732f;
            yDimensions =2.250732f;
            zDimensions =2.250732f;
        }
        mcEnemies.transform.localScale = new Vector3(xDimensions, yDimensions, zDimensions);

    }
}

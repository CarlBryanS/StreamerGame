using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject[] Spawnables;

  //  public ResultScript RS;
   // public UISliding UI;

     float spawnTime;
     float spawnDelay;

    public float xDimensions;
    public float yDimensions;
    public float zDimensions;
    public GameObject parent;
    public float spawnCount;
    public float spawnLimit;
    float timer;
    [SerializeField]bool isSomethingSpawned;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = Random.Range(2, 5);
        isSomethingSpawned = false;
    }

    void Update(){
        if (!isSomethingSpawned&& StreamChosenGame.GOAHEAD)
        {
           timer -= Time.unscaledDeltaTime; 
           if(timer <= 0 ){
               Spawn();
           }  
        }
        //isSomethingSpawned = false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag== "terrorist")
        {
            isSomethingSpawned = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        isSomethingSpawned=false;
        /*if (coll.gameObject.tag== "terrorist")
        {
            isSomethingSpawned = false;       
        }*/
    }
    void Spawn()
    {
        timer = Random.Range(4, 7);
        isSomethingSpawned =true;
        //float randomLocation = Random.Range(this.transform.position.x, 31.11f);
        int randomSpawn = Random.Range(0, Spawnables.Length);
        Vector3 whereToSpawn = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject spawnedTerrorist = Instantiate(Spawnables[randomSpawn], whereToSpawn, transform.rotation) as GameObject;
        spawnedTerrorist.transform.SetParent(parent.transform);
        spawnedTerrorist.transform.localScale = new Vector3(xDimensions, yDimensions, zDimensions);

    }
}

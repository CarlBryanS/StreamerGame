using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject[] Spawnables;

    public ResultScript RS;

    public float spawnTime;
    public float spawnDelay;
    private static int PopupsCount;
    private float PopupLimit;

    // Start is called before the first frame update
    void OnEnable()
    {
        PopupLimit = RS.ViewersForTheDay;
        PopupsCount = 0;
        InvokeRepeating("Spawn", spawnTime, spawnDelay);



    }

    void Update()
    {
        if (PopupsCount >= PopupLimit)
            CancelInvoke("Spawn");
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }
    public void Spawn()
    {
        float randomLocation = Random.Range(-43.87f, -26.95f);
        int randomSpawn = Random.Range(0, 2);
        Vector3 whereToSpawn = new Vector3(randomLocation, this.transform.position.y, this.transform.position.z);
        Instantiate(Spawnables[randomSpawn], whereToSpawn, transform.rotation);
        PopupsCount+= 1;
    }
}

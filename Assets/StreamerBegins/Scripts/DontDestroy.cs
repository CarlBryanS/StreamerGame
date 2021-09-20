using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static bool created = false;

    void Awake()
    {
            if (!created)
            {
                DontDestroyOnLoad(this.gameObject);
                created = true;
                
            }
    }
    void Update(){
                Scene scene = SceneManager.GetActiveScene();
                if(scene.buildIndex ==3 || scene.buildIndex ==4){
                    Destroy(this.gameObject);
                }
    }

}

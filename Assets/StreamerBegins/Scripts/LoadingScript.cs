using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    bool fadeIn;
 
    // Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

    float timer = 10;
    public MeshRenderer cover;

    public TMP_Text loadingText;
    
 
    // Use this for initialization
    void Awake(){
        timer = 6;
        StartCoroutine("changeLoadingText");
    }
    void Start () {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
  
    }
     
    // Update is called once per frame
    void Update () {
        // Spin object around Y-Axis
         transform.Rotate(Vector3.up * 100 * Time.deltaTime);
 
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
        timer -= Time.unscaledDeltaTime;

    }
    IEnumerator changeLoadingText(){
        while(timer >=0){
            loadingText.SetText("Loading");
            yield return new WaitForSeconds(0.3f);
            loadingText.SetText("Loading.");
            yield return new WaitForSeconds(0.3f);
            loadingText.SetText("Loading..");
            yield return new WaitForSeconds(0.3f);
            loadingText.SetText("Loading...");
            yield return new WaitForSeconds(0.3f);
        }
        SceneManager.LoadScene(2);
    }
}

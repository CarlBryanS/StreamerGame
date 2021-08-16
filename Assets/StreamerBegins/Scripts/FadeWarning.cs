using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeWarning : MonoBehaviour
{
    bool StartFadeOut;
    bool StartFadeIn;

    CanvasGroup AlphaGroup;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindObjectOfType<SoundManager>().PlaySound(FindObjectOfType<SoundManager>().clickErrorSound);   
        StartCoroutine("Donation");  
    }

    void Start(){
        AlphaGroup= GetComponent<CanvasGroup>();
    }

    void OnDisable(){
        AlphaGroup.alpha = 1;
    }
    // Update is called once per frame
    void Update()
    {

        if(StartFadeOut){
            AlphaGroup.alpha -= Time.unscaledDeltaTime/1.2f;
        }
    }
        IEnumerator Donation()
    {
        yield return new WaitForSeconds(0.5f);
        StartFadeOut = true;
        yield return new WaitUntil(() =>AlphaGroup.alpha == 0);
        StartFadeOut = false;
        this.gameObject.SetActive(false);
    }
}

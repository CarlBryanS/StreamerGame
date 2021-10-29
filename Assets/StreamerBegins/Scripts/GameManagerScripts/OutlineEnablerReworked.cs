using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OutlineEnablerReworked : MonoBehaviour
{
    public Outline[] outline;

    public virtual void OnMouseEnter()
    {
        EnableOutline();      
    }

    public virtual void OnMouseExit()
    {
        DisableOutline();
    }

    public void EnableOutline(){
        StopAllCoroutines();
        for (int i = 0; i < outline.Length; i++)
            {
                StartCoroutine(SetOutlineAlpha(true, outline[i], outline[i].OutlineColor.a, 1));
            }
    }

    public void DisableOutline(){
        StopAllCoroutines();
         for (int i = 0; i < outline.Length; i++)
            {
               StartCoroutine(SetOutlineAlpha(false, outline[i], outline[i].OutlineColor.a, 0));
            }
    }

    IEnumerator SetOutlineAlpha(bool isHighlighting, Outline outline, float startAlpha, float targetAlpha){
        outline.OutlineColor = new Color (outline.OutlineColor.r,outline.OutlineColor.g,outline.OutlineColor.b,startAlpha);
        float newAlpha = startAlpha;
        if(isHighlighting){
             outline.OutlineWidth = 10;
             while(outline.OutlineColor.a <= targetAlpha && outline.OutlineColor.a <1){
                newAlpha += (Time.unscaledDeltaTime * 8); 
                outline.OutlineColor = new Color (outline.OutlineColor.r,outline.OutlineColor.g,outline.OutlineColor.b,newAlpha);
                yield return null;
             }
        }
        else{
            while(outline.OutlineColor.a >= targetAlpha&& outline.OutlineColor.a >=0){
                newAlpha -= (Time.unscaledDeltaTime * 8); 
                outline.OutlineColor = new Color (outline.OutlineColor.r,outline.OutlineColor.g,outline.OutlineColor.b,newAlpha);
                yield return null;
            }
            outline.OutlineWidth = 0;
        }  
        yield return null;
    }
}

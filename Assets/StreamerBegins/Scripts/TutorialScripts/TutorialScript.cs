using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class TutorialIndex{
    public const int Event1 =2;
    public const int Event2 =6;
    public const int Event3 =7;
    public const int Event4 =9;
    public const int Event5 =12;
    public const int Event6 =14;
    public const int Event7 =16;
    public const int Event8 =18;
    public const int Event9 =19;
    public const int End =21;
    

}
public class TutorialScript : DialogueScript
{
    public TutorialOutlines BedOutline;
    public TutorialOutlines PcOutline;
    public TutorialOutlines DoorOutline;
    public UnityEvent ToggleBrendan;
    public UnityEvent ToggleHighlights;
    public UnityEvent OpenPC;
    public UnityEvent MakeFoodPricesFree;
    public UnityEvent RestoreFoodPrices;

    public override void OnEnable()
    {
        TextActive = true;
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void GoNextLine()
    { 
       if(base.IsLineOver()){  
           switch(index){
            case TutorialIndex.Event1:
                StartCoroutine(Event1());            
                break;
            case TutorialIndex.Event2:
                StartCoroutine(Event2());   
                break;
            case TutorialIndex.Event3:
                StartCoroutine(Event3());   
                break;
            case TutorialIndex.Event4:
                StartCoroutine(Event4());   
                break;
            case TutorialIndex.Event5:
                StartCoroutine(Event5());   
                break;
            case TutorialIndex.Event6:
                StartCoroutine(Event6());
                break;
            case TutorialIndex.Event7:
                StartCoroutine(Event7());
                break;
            case TutorialIndex.Event8:
                StartCoroutine(Event8());
                break;
            case TutorialIndex.Event9:
                StartCoroutine(Event9());
                break;
            case TutorialIndex.End:
                StartCoroutine(End());
                break;
            default:
                base.GoNextLine();
                break;
             
           }
        } 
         else{
            base.GoNextLine();
        }
    }

    IEnumerator Event1(){
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(1f);
        ToggleBrendan.Invoke();
        yield return new WaitForSeconds(1f);
        ShowDialogueBox.Invoke();
        base.GoNextLine();
    }
    IEnumerator Event2(){
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(1f);
        BedOutline.EnableOutline();
        yield return new WaitForSeconds(0.5f);
        BedOutline.DisableOutline();
        yield return new WaitForSeconds(0.5f);
        DoorOutline.EnableOutline();
        yield return new WaitForSeconds(0.5f);
        DoorOutline.DisableOutline();
        yield return new WaitForSeconds(0.5f);
        PcOutline.EnableOutline();
        yield return new WaitForSeconds(0.5f);
        PcOutline.DisableOutline();
        ShowDialogueBox.Invoke();
        base.GoNextLine();
    }
    IEnumerator Event3(){
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(1f);
        PcOutline.EnableOutline();
        yield return new WaitForSeconds(0.5f);
        OpenPC.Invoke();
        PcOutline.DisableOutline();
        yield return new WaitForSeconds(0.5f);
        HideNextButton.Invoke();
        ShowDialogueBox.Invoke();
        base.GoNextLine();
        while(TutorialTriggerCheck.TutorialProgress == 0){
            yield return null;
        }
        ShowDialogueBox.Invoke();
        ShowNextButton.Invoke();
    }
    IEnumerator Event4(){
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==1){
            yield return null;
        }
        base.GoNextLine();
        ShowDialogueBox.Invoke();      
    }
    IEnumerator Event5(){    
        HideDialogueBox.Invoke();
        TextActive = false;
        while(TutorialTriggerCheck.TutorialProgress ==2){
            yield return null;
        }
        base.GoNextLine();
        ShowDialogueBox.Invoke();
    }
    IEnumerator Event6(){
        HideDialogueBox.Invoke();
        MakeFoodPricesFree.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==3){
            yield return null;
        }
        RestoreFoodPrices.Invoke();
        base.GoNextLine();
        ShowDialogueBox.Invoke();
    }
    IEnumerator Event7(){
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==4){
            yield return null;
        }
        base.GoNextLine();
        ShowDialogueBox.Invoke();
    }
    IEnumerator Event8(){
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==5){
            yield return null;
        }
        base.GoNextLine();
        ShowDialogueBox.Invoke();
    }
    IEnumerator Event9(){
        TextActive = true;
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==6){
            yield return null;
        }
        base.GoNextLine();
        ShowDialogueBox.Invoke();
    }
    IEnumerator End(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}

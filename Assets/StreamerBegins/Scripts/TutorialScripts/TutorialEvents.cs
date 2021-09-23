using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TutorialEvents : DialogueEvents
{
    public TutorialScript TutorialScript;
    public TutorialOutlines BedOutline;
    public TutorialOutlines PcOutline;
    public TutorialOutlines DoorOutline;
    public UnityEvent ToggleBrendan;
    public UnityEvent MakeFoodPricesFree;
    public UnityEvent RestoreFoodPrices;

    public IEnumerator Event1(){
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(1f);
        ToggleBrendan.Invoke();
        yield return new WaitForSeconds(1f);
        ShowDialogueBox.Invoke();
        TutorialScript.JustGoNextLine();
    }
    public IEnumerator Event2(){
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(1f);
        BedOutline.EnableOutline();
        DoorOutline.EnableOutline();
        PcOutline.EnableOutline();
        yield return new WaitForSeconds(1f);
        BedOutline.DisableOutline();
        DoorOutline.DisableOutline();
        yield return new WaitForSeconds(0.5f);
        ShowDialogueBox.Invoke();
        TutorialScript.JustGoNextLine();
    }
    public IEnumerator Event3(){
        TutorialScript.TextOff();
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.State == TutorialTriggerCheck.TutorialState.Start){
            yield return null;
        }
        PcOutline.DisableOutline();
        while(TutorialTriggerCheck.TutorialProgress == 0){
            yield return null;
        }
        TutorialScript.TextOn();
        ShowDialogueBox.Invoke();
        TutorialScript.JustGoNextLine();
    }
    public IEnumerator Event4(){
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==1){
            yield return null;
        }
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();      
    }
    public IEnumerator Event5(){    
        HideDialogueBox.Invoke();
        TutorialTriggerCheck.State = TutorialTriggerCheck.TutorialState.Door;
        TutorialScript.TextActive = false;
        while(TutorialTriggerCheck.TutorialProgress ==2){
            yield return null;
        }
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();
    }
    public IEnumerator Event6(){
        HideDialogueBox.Invoke();
        MakeFoodPricesFree.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==3){
            yield return null;
        }
        RestoreFoodPrices.Invoke();
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();
        DoorOutline.DisableOutline();
    }
    public IEnumerator Event7(){
        HideDialogueBox.Invoke();
        TutorialScript.TextActive = false;
        TutorialTriggerCheck.State = TutorialTriggerCheck.TutorialState.Sleep;
        while(TutorialTriggerCheck.TutorialProgress ==4){
            yield return null;
        }
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();
    }
    public IEnumerator Event8(){
        HideDialogueBox.Invoke();
        TutorialScript.TextActive = false;
        TutorialTriggerCheck.State = TutorialTriggerCheck.TutorialState.Door;
        while(TutorialTriggerCheck.TutorialProgress ==5){
            yield return null;
        }
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();
    }
    public IEnumerator Event9(){
        TutorialScript.TextActive = true;
        HideDialogueBox.Invoke();
        while(TutorialTriggerCheck.TutorialProgress ==6){
            yield return null;
        }
        TutorialScript.JustGoNextLine();
        ShowDialogueBox.Invoke();
    }
    public IEnumerator End(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}

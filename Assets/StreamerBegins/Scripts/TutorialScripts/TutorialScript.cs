using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialScript : DialogueScript
{
    public OutlineEnablerReworked BedOutline;
    public OutlineEnablerReworked DoorOutline;
    public OutlineEnablerReworked PCOutline;

    public override void OnEnable()
    {
        TextActive = true;
        base.OnEnable();
    }
    public override void GoNextLine()
    { 
        if(base.IsLineOver()){
            switch(index){
                case 1:
                    StartCoroutine(Event1());
                    break;
                case 2:
                    StartCoroutine(Event2());
                    break;
                case 5:
                    Debug.Log("event3");
                    break;
                case 9:
                    Debug.Log("event4");
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
        HideNextButton.Invoke();
        yield return new WaitForSeconds(0.3f);
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(0.3f);
        BedOutline.EnableOutline();
        yield return new WaitForSeconds(1f);
        BedOutline.DisableOutline();
        yield return new WaitForSeconds(1f);
        DoorOutline.EnableOutline();
        yield return new WaitForSeconds(1f);
        DoorOutline.DisableOutline();
        yield return new WaitForSeconds(1f);
        PCOutline.EnableOutline();
        yield return new WaitForSeconds(1f);
        PCOutline.DisableOutline();
        yield return new WaitForSeconds(0.3f);
        base.GoNextLine();
        ShowDialogueBox.Invoke();
        ShowNextButton.Invoke();  
    }

    IEnumerator Event2(){
        HideNextButton.Invoke();
        yield return new WaitForSeconds(0.3f);
        HideDialogueBox.Invoke();
        yield return new WaitForSeconds(0.3f);
    }
}

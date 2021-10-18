using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class TutorialIndex{
    public const int Event1 =2;
    public const int Event2 =7;
    public const int Event3 =8;
    public const int Event4 =9;
    public const int Event4_5=10;
    public const int Event5 =13;
    public const int Event6 =15;
    public const int Event7 =17;
    public const int Event8 =19;
    public const int Event9 =20;
    public const int End =23;
}
public class TutorialScript : DialogueScript
{
    public TutorialEvents TutorialEvents;
    public GameObject DialogueBox;
    public DialogueNode node;

    private void Update() {
        if(TextActive&&DialogueBox.activeSelf){
            if(Input.GetKeyDown(KeyCode.Space) ||Input.GetKeyDown(KeyCode.Mouse0)){
                GoNextLine();
            }
        }
    }

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
            /*case TutorialIndex.Event1:
                StartCoroutine(TutorialEvents.Event1());            
                break;
            case TutorialIndex.Event2:
                StartCoroutine(TutorialEvents.Event2());   
                break;
            case TutorialIndex.Event3:
                StartCoroutine(TutorialEvents.Event3());   
                break;
            case TutorialIndex.Event4:
                StartCoroutine(TutorialEvents.Event4());   
                break;
            case TutorialIndex.Event4_5:
                StartCoroutine(TutorialEvents.Event4_5());   
                break;    
            case TutorialIndex.Event5:
                StartCoroutine(TutorialEvents.Event5());   
                break;
            case TutorialIndex.Event6:
                StartCoroutine(TutorialEvents.Event6());
                break;
            case TutorialIndex.Event7:
                StartCoroutine(TutorialEvents.Event7());
                break;
            case TutorialIndex.Event8:
                StartCoroutine(TutorialEvents.Event8());
                break;
            case TutorialIndex.Event9:
                StartCoroutine(TutorialEvents.Event9());
                break;
            case TutorialIndex.End:
                StartCoroutine(TutorialEvents.End());
                break;*/
            default:
                base.GoNextLine();
                break;
             
           }
        } 
         else{
            base.GoNextLine();
        }
    }

    public void JustGoNextLine(){
        //base.GoNextLine();
    }
}

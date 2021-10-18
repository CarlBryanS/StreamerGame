using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NameText= null;
    [SerializeField] private TextMeshProUGUI BodyText = null;
    [SerializeField] private DialogueNode dialogueNode = null;
    [SerializeField] private float TextSpeed = 0;
    public static bool TextActive;
    public int index;

    public virtual void OnEnable(){
        NameText.text = dialogueNode.Speaker;
        BodyText.text = string.Empty;
        StartDialogue();
    }
    
    public virtual void OnDisable() {
        TextActive = false;
    }

    public virtual void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in dialogueNode.dialogueLines[index].Line.ToCharArray()){
            BodyText.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    
    }

    public virtual void GoNextLine(){
        if(BodyText.text == dialogueNode.dialogueLines[index].Line){
            CheckNextLine();
        }
        else{
            StopAllCoroutines();
            BodyText.text =dialogueNode.dialogueLines[index].Line;
        }
    }

    void CheckNextLine(){
        if(dialogueNode.dialogueLines[index].Callbacks.Count != 0){
            foreach(UnityEvent Callbacks in dialogueNode.dialogueLines[index].Callbacks)
            {
                Callbacks.Invoke();
            }
        }
        else if(index < dialogueNode.dialogueLines.Length- 1){
            index++;
            BodyText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
        }
    }

    public void TextOn(){
        TextActive = true;
    }

    public void TextOff(){
        TextActive = false;
    }

    public virtual bool IsLineOver(){
        return(BodyText.text == dialogueNode.dialogueLines[index].Line);
    }

    public void ResetDialogueBox(){
            index++;
            BodyText.text = string.Empty;
            StartCoroutine(TypeLine());
    }

}

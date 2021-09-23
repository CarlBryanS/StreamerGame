using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NameText= null;
    [SerializeField] private TextMeshProUGUI BodyText = null;
    [SerializeField] private StringArray TextLines = null;
    [SerializeField] private float TextSpeed = 0;
    public static bool TextActive;
    public int index;

    public virtual void OnEnable(){
        NameText.text = TextLines.speaker;
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
        foreach(char c in TextLines.lines[index].ToCharArray()){
            BodyText.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    public virtual void GoNextLine(){
        if(BodyText.text == TextLines.lines[index]){
            CheckNextLine();
        }
        else{
            StopAllCoroutines();
            BodyText.text =TextLines.lines[index];
        }
    }

    void CheckNextLine(){
        if(index < TextLines.lines.Length - 1){
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
        return(BodyText.text == TextLines.lines[index]);
    }

}

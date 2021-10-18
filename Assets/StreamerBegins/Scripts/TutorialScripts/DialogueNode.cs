using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueLine{
    [TextArea]
    public string Line;
    public List<UnityEvent> Callbacks;
}

public class DialogueNode : MonoBehaviour
{
    public string Speaker;
    public DialogueLine[] dialogueLines;

    public void Start(){

    }
    public void Update(){
    }

    public void Run(){
        foreach(DialogueLine lines in dialogueLines)
        {
            foreach(UnityEvent Callbacks in lines.Callbacks)
            {
                Callbacks.Invoke();
            }
        }
    }
}

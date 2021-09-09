using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineEnablerReworked : MonoBehaviour
{
    public Outline[] outline;

    public virtual void OnMouseEnter()
    {
        EnableOutline();      
    }

    public void OnMouseExit()
    {
        DisableOutline();
    }

    public void EnableOutline(){
        for (int i = 0; i < outline.Length; i++)
            {
                outline[i].OutlineWidth = 4;
            }
    }

    public void DisableOutline(){
         for (int i = 0; i < outline.Length; i++)
            {
                outline[i].OutlineWidth = 0;
            }
    }

}

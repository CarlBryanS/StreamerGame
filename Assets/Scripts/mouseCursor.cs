using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public Texture2D idleCursor;
    public Texture2D clickCursor;
    public Texture2D crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(idleCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
       if(miniGameState.State != miniGameState.mgState.onGoing){
            if(Input.GetMouseButton(0)){
                Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if(Input.GetMouseButtonUp(0)){
                Cursor.SetCursor(idleCursor, Vector2.zero, CursorMode.ForceSoftware);
            }
       }
       else if(miniGameState.State == miniGameState.mgState.onGoing){
           if(CSGOGameScript.csgoActive ==true && StreamChosenGame.GOAHEAD){
               Cursor.SetCursor(crosshair, new Vector2(32,31.5f), CursorMode.ForceSoftware);
           }
       } 

    }
}
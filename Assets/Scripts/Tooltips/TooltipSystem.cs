using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public tooltip tooltip;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    public static void Show(string content, string header = ""){
        current.tooltip.SetText(content, header);   
        current.tooltip.gameObject.SetActive(true);   
    }
    public static void Hide(){
     current.tooltip.gameObject.SetActive(false);
    }
}

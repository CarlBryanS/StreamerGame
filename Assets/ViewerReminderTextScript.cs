using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewerReminderTextScript : MonoBehaviour
{
    public WORLDPARAMETERS WP;
    TMP_Text thisText;
    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        thisText.SetText(WP.Fans + " + " + "???");
    }
}

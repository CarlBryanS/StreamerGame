using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator BrendanAnim;
    public GameObject Brendan;
    public void Sleeping()
    {
        Brendan.transform.localPosition = new Vector3(4.77f, -315.79f, 371.54f);
        Brendan.transform.localEulerAngles = new Vector3(0, -90, 0);
        BrendanAnim.SetBool("isTyping", false);
        BrendanAnim.SetBool("isSleeping", true);
    }

    public void Typing()
    {
        Brendan.transform.localPosition = new Vector3(-1.28f, -317.7f, 361.42f);
        Brendan.transform.localEulerAngles = new Vector3(0, 180, 0);
        BrendanAnim.SetBool("isSleeping", false);
        BrendanAnim.SetBool("isTyping", true);
    }

    public void Idle()
    {
        Brendan.transform.localPosition = new Vector3(3.723f, -317.242f, 369.201f);
        Brendan.transform.localEulerAngles = new Vector3(0, -90, 0);
        BrendanAnim.SetBool("isSleeping", false);
        BrendanAnim.SetBool("isTyping", false);
    }
}

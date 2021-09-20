using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool tutorialChecked = true;
    public void loadlevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void tutorialLevel(){
        if(tutorialChecked){
            SceneManager.LoadScene(2);
        }
        else{
            SceneManager.LoadScene(1);
        }
    }

    public void isTutorialChecked(bool newValue){
        tutorialChecked = newValue;
    }
    public void Quit()
    {
        Application.Quit();
    }

}


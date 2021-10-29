using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeWarningPosition : MonoBehaviour
{
    public RectTransform UpgradeWarning;

    public void UpgradeWarningMoveEvent(int i){
        switch(i){
            case 1:
                MoveUpgradeWarning(33f,28.4f);
                break;
            case 2:
                MoveUpgradeWarning(33f,-4.6f);
                break;
            case 3:
                MoveUpgradeWarning(33f,-38.33f);
                break;    
        }
    }
    public void MoveUpgradeWarning(float x, float y){
        UpgradeWarning.anchoredPosition = new Vector2(x, y);
    }


}

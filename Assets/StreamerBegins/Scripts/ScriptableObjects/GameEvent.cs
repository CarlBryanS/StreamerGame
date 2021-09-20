﻿using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameEvent", menuName = "StreamerGame/GameEvent", order = 0)]
public class GameEvent : ScriptableGameObject {
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise(){
        for(int i = listeners.Count -1; i>=0; i--){
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener){
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListener listener){
        listeners.Remove(listener);
    }
    
}
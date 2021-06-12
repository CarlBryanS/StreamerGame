using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "Blue is sus", "I'm not the impostor", "Red vented", "Green was faking tasks", "Where did he die" };
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}

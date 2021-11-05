using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    
    private void OnEnable() {
    int RandomNumber = Random.Range(0, sprites.Length);
    this.GetComponent<SpriteRenderer>().sprite = sprites[RandomNumber];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeEmotion(Emotion emotion)
    {
        spriteRenderer.sprite = spriteArray[(int)emotion % spriteArray.Length];
    }
}

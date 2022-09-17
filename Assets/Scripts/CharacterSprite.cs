using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private Emotion test = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSprite(Emotion emotion)
    {
        spriteRenderer.sprite = spriteArray[(int)emotion];
    }
}

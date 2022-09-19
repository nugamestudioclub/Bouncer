using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEyeColor : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    Color rendererColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rendererColor = spriteRenderer.color;
    }

    void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    void ChangeColorRandom()
    {
        ChangeColor(new Color(Random.Range(0f, 1f), 
            Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
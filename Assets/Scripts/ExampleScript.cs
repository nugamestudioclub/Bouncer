using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer hatRender;
    [SerializeField]
    private SpriteRenderer headRenderer;


    [SerializeField]
    private List<Sprite> hats;
    [SerializeField]
    private List<Sprite> head;

    private float secondPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectOutfit();
    }

    void SelectOutfit()
    {
        int randomSelect = Random.Range(0, hats.Count);
        hatRender.sprite = hats[randomSelect];
        //randomSelect = Random.Range(0, head.Count);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

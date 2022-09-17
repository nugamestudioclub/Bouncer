using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{

    private Character[] characters;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public Character selectChar()
    {
        int random = Random.Range(0, characters.Length);
        return characters[random];
    }

    //Dummy method
    public bool isLast()
    {
        return false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

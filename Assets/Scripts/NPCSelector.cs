using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelector : MonoBehaviour
{

    private NPC[] characters;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public NPC SelectNPC()
    {
        int random = Random.Range(0, characters.Length);
        return characters[random];
    }

    //Dummy class
    public bool IsLast()
    {
        return false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int size;
    private List<Character> characters;
    private List<Character> queue;

    // Start is called before the first frame update
    void Awake()
    {

    }

    public void GenerateQueue(int size)
    {
        List<Character> unselected = new List<Character>(characters);
        for(int i = 0; i < 15; i++)
        {
            int random = Random.Range(0, unselected.Count);
            Character randChar = unselected[random];
            queue.Add(randChar);
            unselected.RemoveAt(random);
        }
    }

    public Character GetFirstCharacter()
    {
        return queue[0];
    }

    public Character GetNextChararacter()
    {
        Character toReturn = queue[0];
        queue.RemoveAt(0);
        return toReturn;
    }

    /*public Character selectChar()
    {
        int random = Random.Range(0, characters.Length);
        return characters[random];
    }*/

    //Dummy class
    public bool isLast()
    {
        return queue.Count == 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

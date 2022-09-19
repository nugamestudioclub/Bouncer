using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [field: SerializeField]
    public NPCDialogue Dialogue  { get; private set; }
    //public string[] Texts { get; private set; }
    [field: SerializeField]
    public RepEffect Effect { get; private set; }
    // private int index = 0;
    [field: SerializeField]
    public float Patience { get; private set; }

    [SerializeField]
    private List<NPCSprite> sprites;

    public void ChangeEmotion(Emotion emotion)
    {

        Debug.Log($"Emotion: {emotion}");
        foreach(NPCSprite sprite in sprites)
        {
            sprite.ChangeEmotion(emotion);
        }
    }
}

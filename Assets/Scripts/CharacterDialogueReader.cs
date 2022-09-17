using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueReader : MonoBehaviour
{
    List<CharacterDialogue> list;
    private string filepath;

    // Start is called before the first frame update
    private void Awake()
    {
        ReadCharacterDialogue();
    }

    private void ReadCharacterDialogue()
    {
        string[] files = System.IO.Directory.GetFiles(filepath);
        foreach (string file in files)
        {
            TextAsset text = Resources.Load(file) as TextAsset;
            string fileinfo = text.text;
            //Do work on the files here
        }




    }

    public CharacterDialogue GetCharacterDialogue(string name)
    {
        foreach(CharacterDialogue dialogue in list)
        {
            if (dialogue.Name.Equals(name))
            {
                return dialogue;
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueReader : MonoBehaviour
{
    List<CharacterDialogue> list;
    private string filepath;

    // Start is called before the first frame update
    void Start()
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

    CharacterDialogue GetCharacterDialogue(string name)
    {
        foreach(CharacterDialogue dialogue in list)
        {
            // Do stuff
        }
        return null;
    }
}

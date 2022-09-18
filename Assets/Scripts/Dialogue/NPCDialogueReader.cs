using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueReader : MonoBehaviour
{
    List<NPCDialogue> list;
    private string filepath;

    // Start is called before the first frame update
    private void Awake()
    {
        ReadNPCDialogue();
    }

    private void ReadNPCDialogue()
    {
        string[] files = System.IO.Directory.GetFiles(filepath);
        foreach (string file in files)
        {
            TextAsset text = Resources.Load(file) as TextAsset;
            string fileinfo = text.text;
            //Do work on the files here
        }

    }

    public NPCDialogue GetCharacterDialogue(string name)
    {
        foreach (NPCDialogue dialogue in list)
        {
            if (dialogue.Name.Equals(name))
            {
                return dialogue;
            }
        }
        return null;
    }
}

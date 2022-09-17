using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDialogueData
{
    public string name;

    public List<DialogueNodeData> nodes;

    public static CharacterDialogueData CreateFromJSON(string jsonString)
    {
        CharacterDialogueData data = JsonUtility.FromJson<CharacterDialogueData>(jsonString);
        return data;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDialogue
{
    public string Name { get; private set; }
    public List<DialogueNode> Nodes { get; private set; }

    public DialogueNode GetDialogueNode(Label label)
    {
        foreach(DialogueNode node in Nodes)
        {
            if(node.Label.Equals(label)) {
                return node;
            }
        }
        return null;
    }

    public List<DialogueNode> GetNodes()
    {
        return Nodes;
    }
}

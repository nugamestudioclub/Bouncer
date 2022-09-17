using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDialogue
{
    public string Name { get; private set; }
    public List<DialougeNode> Nodes { get; private set; }

    public DialougeNode GetDialogueNode(Label label)
    {
        foreach(DialougeNode node in Nodes)
        {
            if(node.Label.Equals(label)) {
                return node;
            }
        }
        return null;
    }

    public List<DialougeNode> GetNodes()
    {
        return Nodes;
    }
}

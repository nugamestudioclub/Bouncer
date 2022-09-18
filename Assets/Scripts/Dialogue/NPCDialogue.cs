using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogue
{
    public string Name { get; private set; }
    public Dictionary<string, DialogueNode> Nodes { get; private set; }

    public NPCDialogue(NPCDialogueData data)
    {
        Name = data.name;
        Nodes = new();
        foreach (DialogueNodeData nodeData in data.npcNodes)
        {
            nodeData.IsNPC = true;
            Nodes[nodeData.label] = new DialogueNode(nodeData);
        }
        foreach (DialogueNodeData nodeData in data.pcNodes)
        {
            nodeData.IsNPC = false;
            Nodes[nodeData.label] = new DialogueNode(nodeData);
        }
    }
    public DialogueNode GetDialogueNode(string label)
    {
        return Nodes[label];
    }
}

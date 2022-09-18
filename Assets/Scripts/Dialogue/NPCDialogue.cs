using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogue : MonoBehaviour
{
    public string Name { get; private set; }
    public Dictionary<string, DialogueNode> Nodes { get; private set; }

    [SerializeField]
    private TextAsset textData;
    private void Awake()
    {
        Initialize(NPCDialogueData.CreateFromJSON(textData.text));
    }
    public void Initialize(NPCDialogueData data) {
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

        print(Name);
    }
    public DialogueNode GetDialogueNode(string label)
    {
        return Nodes[label];
    }
}

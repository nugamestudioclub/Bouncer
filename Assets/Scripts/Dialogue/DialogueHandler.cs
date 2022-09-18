using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    NPCDialogueReader dialogueReader;
    NPCDialogue dialogueTree;
    DialogueNode currentNode;


    // Start is called before the first frame update
    private void Awake()
    {
        dialogueReader = new NPCDialogueReader();
    }

    void SetCharacterDialogue(string name)
    {
        dialogueTree = dialogueReader.GetCharacterDialogue(name);
        SetCurrentNode(dialogueTree.GetDialogueNode(Label.Intro));
    }

    void SetCurrentNode(DialogueNode node)
    {
        currentNode = node;
    }

    public string GetCurrentText()
    {
        return currentNode.Text;
    }

    public List<DialogueNode> GetLinkedNodes()
    {
        List<DialogueNode> toReturn = new List<DialogueNode>();
        foreach(DialogueNode node in dialogueTree.Nodes)
        {
            if(currentNode.Connections.Contains(node.Label))
            {
                toReturn.Add(node);
            }
        }
        return toReturn;
    }
}

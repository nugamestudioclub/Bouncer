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
        SetCurrentNode(dialogueTree.GetDialogueNode("start"));
    }

    void SetCurrentNode(DialogueNode node)
    {
        currentNode = node;
    }

    public string GetCurrentText()
    {
        return currentNode.Text;
    }


    public IEnumerable<DialogueNode> GetLinkedNodes()
    {
        foreach(var label in currentNode.Connections)
        {
            //TODO: add if conditions are true
            yield return dialogueTree.GetDialogueNode(label);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    //NPCDialogueReader dialogueReader;
    NPCDialogue dialogueTree;
    DialogueNode currentNode;


    // Start is called before the first frame update
    private void Awake()
    {
        //dialogueReader = new NPCDialogueReader();
    }

    public void SetCharacterDialogue(NPCDialogue dialogue)
    {
        dialogueTree = dialogue;
        SetCurrentNode(dialogueTree.GetDialogueNode("start"));
    }

    public void SetCurrentNode(DialogueNode node)
    {
        currentNode = node;
    }

    public DialogueNode GetCurrentNode() {
        return currentNode;
	}

    public void SetCurrentNode(string label)
    {
        currentNode = dialogueTree.GetDialogueNode(label);
    }

    public DialogueNode GetNode(string label) => dialogueTree.GetDialogueNode(label);

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

    public IEnumerable<DialogueNode> GetChildrenOf(DialogueNode node) {
        foreach( var label in node.Connections )
            yield return dialogueTree.GetDialogueNode(label);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{

    public string Label { get; private set; }
    public string Text { get; private set; }
    public List<string> Connections { get; private set; }
    public List<Condition> Conditions { get; private set; }
    public List<Effects> Effects { get; private set; }

    public bool IsNPC { get; private set; }

    public DialogueNode(DialogueNodeData data)
    {
        this.Label = data.label;
        this.Text = data.text;

        //TODO Abstract redundant behavior
        this.Connections = new ();
        foreach (string connection in data.connections)
        {
            this.Connections.Add(connection);
        }
        this.Conditions = new ();
        foreach (string condition in data.conditions)
        {
            this.Conditions.Add(Enum.Parse<Condition>(condition));
        }
        // data.conditions.Map(condition => Enum.Parse<Condition>(condition));
        this.Effects = new ();
        foreach (string effect in data.effects)
        {
            this.Effects.Add(Enum.Parse<Effects>(effect));
        }

        IsNPC = data.IsNPC;
    }
}

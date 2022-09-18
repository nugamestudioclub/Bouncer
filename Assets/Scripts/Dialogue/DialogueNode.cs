using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{

    public Label Label { get; private set; }
    public string Text { get; private set; }
    public List<Label> Connections { get; private set; }
    public List<Conditions> Conditions { get; private set; }
    public List<Effects> Effects { get; private set; }

    public DialogueNode(DialogueNodeData data)
    {
        this.Label = Enum.Parse<Label>(data.label);
        this.Text = data.text;

        //TODO Abstract redundant behavior
        this.Connections = new List<Label>();
        foreach (string connection in data.connections)
        {
            this.Connections.Add(Enum.Parse<Label>(connection));
        }
        this.Conditions = new List<Conditions>();
        foreach (string condition in data.conditions)
        {
            this.Conditions.Add(Enum.Parse<Conditions>(condition));
        }
        // data.conditions.Map(condition => Enum.Parse<Condition>(condition));
        this.Effects = new List<Effects>();
        foreach (string effect in data.effects)
        {
            this.Effects.Add(Enum.Parse<Effects>(effect));
        }
    }
}

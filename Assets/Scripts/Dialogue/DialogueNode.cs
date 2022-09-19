using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{

    public string Label { get; private set; }
    public string Text { get; private set; }
    public List<string> Connections { get; private set; }
    public List<Condition> Conditions { get; private set; }
    public List<Effects> Effects { get; private set; }

    public Emotion Emotion { get; private set; }

    public bool IsNPC { get; private set; }

    public DialogueNode(DialogueNodeData data)
    {
        Label = data.label;
        Text = data.text;

        var enumNames = from x in Enum.GetNames(typeof(Emotion)) select x.ToLower();
        var enumValues = (int[])Enum.GetValues(typeof(Emotion));

        Emotion = string.IsNullOrEmpty(data.emotion)
            ? Emotion.Neutral
            : (Emotion)enumValues[enumNames.ToList().IndexOf(data.emotion.ToLower())];

        //TODO Abstract redundant behavior
        Connections = new ();
        foreach (string connection in data.connections)
        {
            Connections.Add(connection);
        }
        Conditions = new ();
        foreach (string condition in data.conditions)
        {
            Conditions.Add(Enum.Parse<Condition>(condition));
        }
        // data.conditions.Map(condition => Enum.Parse<Condition>(condition));
        Effects = new ();
        foreach (string effect in data.effects)
        {
            Effects.Add(Enum.Parse<Effects>(effect));
        }

        IsNPC = data.IsNPC;
    }
}
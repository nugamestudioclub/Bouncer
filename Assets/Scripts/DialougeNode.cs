using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeNode
{

    public Label Label{ get; private set; }
    public string Text { get; private set; }
    public List<Label> Connections { get; private set; }
    public List<Conditions> Conditions { get; private set; }
    public List<Effects> Effects { get; private set; }
}

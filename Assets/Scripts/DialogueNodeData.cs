using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNodeData {
   public string label;
   public string text;
   public List<string> connections;
   public List<string> conditions;
   public List<string> effects;


   public static DialogueNodeData CreateFromJSON(string jsonString) {
        DialogueNodeData data = JsonUtility.FromJson<DialogueNodeData>(jsonString);
        return data;
    }
}
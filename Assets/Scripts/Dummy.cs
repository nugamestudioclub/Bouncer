using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour {
    [SerializeField] 
    TextAsset jsonFile;

    // string payload = ; //,text:lorumipsum,connections:[bounce,admit],conditions:[3star,midnight],effects:[reputation+]}";
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("HI");
            CharacterDialogueData.CreateFromJSON(jsonFile.text);
        }
    }
}
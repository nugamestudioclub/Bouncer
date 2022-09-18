using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORT THIS FOR GUI ELEMENTS
using UnityEngine.UI;

public class ReferenceMaterial : MonoBehaviour
{
    public Image img;
    public Button btn;
    public Sprite sprite;
    public SpriteRenderer rend;

    public Text text;

    


    // Start is called before the first frame update
    void Start()
    {
        rend.sprite = sprite;
        btn.onClick.AddListener(Clicked);
        //change pos
        img.transform.position = new Vector3(1, 1, 1);
        text.text = "Hello";
        text.text = "$"+5.ToString();


       
    }

    void LoadJson()
    {
        string rootPath = Application.dataPath + @"\Resources";
        MySerializedJson json = JsonUtility.FromJson<MySerializedJson>(Application.dataPath+"//"+"myJson.json");

        
    }

    void Clicked()
    {
        print("CLICKED!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
class MySerializedJson
{
    public int id;
    public string text;
    public string playerName;

}

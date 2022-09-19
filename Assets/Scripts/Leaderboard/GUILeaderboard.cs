using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUILeaderboard : MonoBehaviour
{
    public GameObject scoreItem;
    private int offset = 0;
    [SerializeField]
    private int appliedOffset = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CreateNewItem(string name, int score)
    {
        GameObject obj = Instantiate(scoreItem, this.transform);
        obj.GetComponent<LeaderboardScore>().SetName(name);
        obj.GetComponent<LeaderboardScore>().SetValue(score);
        print(Screen.height);
        
        
        obj.transform.position += Vector3.down * appliedOffset*offset*Screen.height*0.002f;
        offset += 1;
    }

    public void Load(SerializedLeaderboardData[] data)
    {
        foreach(SerializedLeaderboardData item in data)
        {
            CreateNewItem(item.name, item.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
           // CreateNewItem("seb", 5);
    }



}

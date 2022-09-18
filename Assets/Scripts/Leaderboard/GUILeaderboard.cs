using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUILeaderboard : MonoBehaviour
{
    public GameObject scoreItem;
    private int offset = 1;
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
        obj.transform.position += Vector3.down * appliedOffset*offset;
        offset += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            CreateNewItem("seb", 5);
    }



}
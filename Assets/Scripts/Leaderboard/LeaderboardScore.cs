using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardScore : MonoBehaviour
{

    
    private TMP_Text scoreName;
    
    private TMP_Text scoreValue;

    [SerializeField]
    private int scoreVal = 0;
    [SerializeField]
    private string playerName = "";


    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        foreach(TMP_Text text in texts)
        {
            if(text.name == "Name")
            {
                this.scoreName = text;
            }else if(text.name == "Score")
            {
                this.scoreValue = text;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.scoreName.text = playerName;
        this.scoreValue.text = scoreVal.ToString();
    }
    public void SetName(string name)
    {
        this.playerName = name;
    }
    public void SetValue(int value)
    {
        this.scoreVal = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Submit();
        }
        
    }

    void Submit()
    {
        string memberID = "Seb";
        int leaderboardID = 7117;
        int score = 150;

    }
}

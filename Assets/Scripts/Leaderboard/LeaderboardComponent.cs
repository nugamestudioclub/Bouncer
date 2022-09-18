using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;


public class LeaderboardComponent : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private string playerName = "Seb";
    int leaderboardID = 7117;

    public GUILeaderboard gui;
 

    // Start is called before the first frame update
    void Start()
    {
        
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
            PlayerPrefs.SetInt("id", response.player_id);
        });
        print(score.ToString() + " set as score");
        
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
        string memberID = "Sebastian";
        
        print("Submitting:" + this.score.ToString());

       
        LootLockerSDKManager.SubmitScore(memberID, this.score, leaderboardID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });

        LootLockerSDKManager.SetPlayerName(this.playerName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Error setting player name");
            }
        });
        StartCoroutine(FetchTopHighScoreRoutine());
    }

    public IEnumerator FetchTopHighScoreRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(this.leaderboardID, 10, 0, (response) =>
         {
             if (response.success)
             {
                 LootLockerLeaderboardMember[] members = response.items;
                 SerializedLeaderboardData[] data = new SerializedLeaderboardData[members.Length];
                 int index = 0;
                 foreach(LootLockerLeaderboardMember member in members)
                 {
                     data[index] = new SerializedLeaderboardData();
                     data[index].name = member.player.name;
                     data[index].score = member.score;
                     print("Loaded Name:" + data[index].name+","+data[index].score);
                     
                     index++;
                     
                 }
                 string jsonData = JsonUtility.ToJson(data);
                 PlayerPrefs.SetString("scores", jsonData);
                 gui.Load(data);
                // print("Loaded Scores:"+jsonData);
             }
             else
             {
                 PlayerPrefs.SetString("scores", "none");
             }
         });
        yield return new WaitWhile(()=>  done == false);
    }
}



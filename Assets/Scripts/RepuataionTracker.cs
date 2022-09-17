using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepuataionTracker : MonoBehaviour
{

    private int score;

    // Reduces the score of the player as a result of a major problem
    void MajorProblem() 
    {
        this.score -= 20;
    }

    // Reduces the score of the player as a result of a minor problem
    void MinorProblem()
    {
        this.score -= 5;
    }

    // Adds to the score of the player as a result of a minor merit
    void MinorGood()
    {
        this.score += 5;
    }

    // Adds to the score of the player as a result of a major merit
    void MajorGood()
    {
        this.score += 20;
    }

    public void load();
}

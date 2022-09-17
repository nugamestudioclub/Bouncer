using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationTracker : MonoBehaviour
{

    private int score;

    // Reduces the score of the player as a result of a major problem
    public void MajorProblem() 
    {
        this.score -= 20;
    }

    // Reduces the score of the player as a result of a minor problem
    public void MinorProblem()
    {
        this.score -= 5;
    }

    // Adds to the score of the player as a result of a minor merit
    public void MinorGood()
    {
        this.score += 5;
    }

    // Adds to the score of the player as a result of a major merit
    public void MajorGood()
    {
        this.score += 20;
    }

    public void load() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationTracker : MonoBehaviour
{
    public int Rep { get; private set; }
    public static readonly int EndThreshold = -100;
    public static readonly int MINOR = 5;
    public static readonly int MAJOR = 20;


    // Reduces the rep of the player as a result of a major problem
    public void MajorProblem()
    {
        this.Rep -= MAJOR;
    }

    // Reduces the rep of the player as a result of a minor problem
    public void MinorProblem()
    {
        this.Rep -= MINOR;
    }

    // Adds to the rep of the player as a result of a minor merit
    public void MinorGood()
    {
        this.Rep += MINOR;
    }

    // Adds to the rep of the player as a result of a major merit
    public void MajorGood()
    {
        this.Rep += MAJOR;
    }
}

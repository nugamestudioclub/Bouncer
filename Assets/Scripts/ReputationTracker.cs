using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationTracker : MonoBehaviour
{
    public int Rep
    {
        get
        {
            return this.rep;
        }
    }

    public int EndThreshold
    {
        get
        {
            return ENDTHRESHOLD;
        }
    }

    private int rep;
    private int ENDTHRESHOLD = -100;
    private int MINOR = 5;
    private int MAJOR = 20;
    

    // Reduces the rep of the player as a result of a major problem
    public void MajorProblem() 
    {
        this.rep -= this.MAJOR;
    }

    // Reduces the rep of the player as a result of a minor problem
    public void MinorProblem()
    {
        this.rep -= this.MINOR;
    }

    // Adds to the rep of the player as a result of a minor merit
    public void MinorGood()
    {
        this.rep += this.MINOR;
    }

    // Adds to the rep of the player as a result of a major merit
    public void MajorGood()
    {
        this.rep += this.MAJOR;
    }
}

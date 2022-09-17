using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepuataionTracker : MonoBehaviour
{
    public int Rep { get { return this.rep; } }

    private int rep;

    // Reduces the rep of the player as a result of a major problem
    public void MajorProblem() 
    {
        this.rep -= 20;
    }

    // Reduces the rep of the player as a result of a minor problem
    public void MinorProblem()
    {
        this.rep -= 5;
    }

    // Adds to the rep of the player as a result of a minor merit
    public void MinorGood()
    {
        this.rep += 5;
    }

    // Adds to the rep of the player as a result of a major merit
    public void MajorGood()
    {
        this.rep += 20;
    }

    
}

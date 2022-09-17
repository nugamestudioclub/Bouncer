using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepuataionTracker : MonoBehaviour
{

    private int rep;

<<<<<<< Updated upstream
    // Reduces the score of the player as a result of a major problem
    void MajorProblem() 
=======
    // Reduces the rep of the player as a result of a major problem
    public void MajorProblem() 
>>>>>>> Stashed changes
    {
        this.rep -= 20;
    }

<<<<<<< Updated upstream
    // Reduces the score of the player as a result of a minor problem
    void MinorProblem()
=======
    // Reduces the rep of the player as a result of a minor problem
    public void MinorProblem()
>>>>>>> Stashed changes
    {
        this.rep -= 5;
    }

<<<<<<< Updated upstream
    // Adds to the score of the player as a result of a minor merit
    void MinorGood()
=======
    // Adds to the rep of the player as a result of a minor merit
    public void MinorGood()
>>>>>>> Stashed changes
    {
        this.rep += 5;
    }

<<<<<<< Updated upstream
    // Adds to the score of the player as a result of a major merit
    void MajorGood()
=======
    // Adds to the rep of the player as a result of a major merit
    public void MajorGood()
>>>>>>> Stashed changes
    {
        this.rep += 20;
    }

    public void load();
}

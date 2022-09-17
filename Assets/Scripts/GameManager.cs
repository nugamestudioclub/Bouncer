using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private int nightCount = 0;
    public int NightCount { get { return nightCount; } }

    private CharacterSelector selector;

    //TODO: Create ReputationTracker.cs script and implement the following functions:
    //MajorProblem(), MinorProblem(), MajorGood(), MinorGood() and load() which can be left empty.
    //Each function when called will apply changes to Rep.
    //Also note: ONCE YOU CREATE THIS CLASS delete the DUMMY CLASS of ReputationTracker in the bottom of this script.
    
    private ReputationTracker tracker;


    private string activeText = "";

    public static GameManager instance;

    private Character activeCharacter;

    // Start is called before the first frame update
    void Start()
    {
       

        instance = this;
        //Loading/serializing data.
        Character character = selector.selectChar();
        activeText = character.getText();
    }

    //Iterates to the next night.
    void IterateNight()
    {
        this.nightCount++;
        //run conditions.
    }

    //Will be called when a player clicks the "Admit" button.
    void Admit(Character character)
    {
        switch (character.Admit())
        {
            case 0:
                tracker.MajorProblem();
                break;
            case 1:
                tracker.MinorProblem();
                break;
            case 2:
                tracker.MinorGood();
                break;
            case 3:
                tracker.MajorGood();
                
                break;
        }

    }
    //Will be called when the player clicks the "Bounce" button.
    void Bounce(Character character)
    {
        switch (character.Bounce())
        {
            case 0:
                tracker.MajorProblem();
                break;
            case 1:
                tracker.MinorProblem();
                break;
            case 2:
                tracker.MinorGood();
                break;
            case 3:
                tracker.MajorGood();
                break;

        }
    }

    void CheckRepTooLow()
    {
        if (tracker.Rep < -100)
        {
            this.EndGame();
        }
        else
        {
            this.IsLastCharacer();
        }
    }

    void EndGame()
    {

    }

    void IsLastCharacer()
    {
        if (selector.isLast()) {
            this.activeCharacter = selector.selectChar();
        }
        else {
            this.ResetNight();
        }
    }
    
    /// <summary>
    /// if is END GAME
    /// if not new night
    /// </summary>
    void ResetNight()
    {
        this.IterateNight();
    }
    

    void IterateChoice()
    {

    }

    void Stormout()
    {

    }

    bool IsOutOfTime()
    {
        //reference global timer 
        return false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}

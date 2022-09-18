using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    public int NightCount { get; private set; }
    public float GameTime { get; private set; }

    private NPCSelector selector;
    private float characterTime = 0; // Tracks the time spent by 

    //TODO: Create ReputationTracker.cs script and implement the following functions:
    //MajorProblem(), MinorProblem(), MajorGood(), MinorGood() and load() which can be left empty.
    //Each function when called will apply changes to Rep.
    //Also note: ONCE YOU CREATE THIS CLASS delete the DUMMY CLASS of ReputationTracker in the bottom of this script.

    private ReputationTracker tracker;

    private string activeText = "";

    public static GameManager instance;

    private NPC activeCharacter;

    private List<bool> conditionStates;

    // Start is called before the first frame update
    void Awake()
    {

        instance = this;
        //Loading/serializing data.
        NPC character = selector.SelectNPC();
        activeText = character.getText();
        var values = Enum.GetValues(typeof(Condition));
        conditionStates = new List<bool>(values.Length);
        foreach(var _ in values) 
            conditionStates.Add(false);
        
    }

    public bool CheckCondition(Condition condition)
    {
        return conditionStates[(int)condition];
    }

    //Iterates to the next night.
    void IterateNight()
    {
        NightCount++;
        //run conditions.
    }

    //Will be called when a player clicks the "Admit" button.
    void Admit(NPC character)
    {
        switch (character.Effect)
        {
            case RepEffect.MajorProblem:
                tracker.MajorProblem();
                break;
            case RepEffect.MinorProblem:
                tracker.MinorProblem();
                break;
            case RepEffect.MinorGood:
                tracker.MinorGood();
                break;
            case RepEffect.MajorGood:
                tracker.MajorGood();
                break;
        }

    }
    //Will be called when the player clicks the "Bounce" button.
    void Bounce(NPC character)
    {
        switch (character.Effect)
        {
            case RepEffect.MajorProblem:
                tracker.MajorGood();
                break;
            case RepEffect.MinorProblem:
                tracker.MinorGood();
                break;
            case RepEffect.MinorGood:
                tracker.MinorProblem();
                break;
            case RepEffect.MajorGood:
                tracker.MajorProblem();
                break;

        }
    }

    void CheckRepTooLow()
    {
        // If the reputation gets below a threshold, end game
        if (tracker.Rep < ReputationTracker.EndThreshold)
        {
            this.EndGame();
        }

        // checks for the last character or we reset the night instead
        else
        {
            this.IsLastCharacter();
        }
    }

    void EndGame()
    {

    }

    void IsLastCharacter()
    {
        // 
        if (selector.IsLast())
        {

            this.activeCharacter = selector.SelectNPC();
        }

        // 
        else
        {
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
        ResetGameTime();
    }


    void IterateChoice()
    {

    }

    void Stormout()
    {

    }

    // Reset time when night ends
    void ResetGameTime()
    {
        GameTime = 0;
    }

    // Start the timer for a new character
    void StartCharacterTime()
    {
        characterTime = GameTime;
    }

    // Get the time spent by a character
    float GetCharacterTime()
    {
        return GameTime - characterTime;
    }

    // Get the time remaining before patience runs out
    float CharacterPatienceRemaining(NPC character)
    {
        return character.Patience - GetCharacterTime();
    }

    // Reset time for the next character in queue
    void ResetCharacterTime()
    {
        characterTime = 0;
    }

    bool IsOutOfTime()
    {
        //reference global timer    
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
    }
}

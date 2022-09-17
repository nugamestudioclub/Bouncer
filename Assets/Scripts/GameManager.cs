using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int nightCount = 0;
    public int NightCount { get { return nightCount; } }
    
    public int NetWorth = 0; // Net worth of the bouncer
    private CharacterSelector selector;

    //TODO: Create ReputationTracker.cs script and implement the following functions:
    //MajorProblem(), MinorProblem(), MajorGood(), MinorGood() and load() which can be left empty.
    //Each function when called will apply changes to Rep.
    //Also note: ONCE YOU CREATE THIS CLASS delete the DUMMY CLASS of ReputationTracker in the bottom of this script.
    private ReputationTracker tracker;


    private string activeText = "";

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //Loading/serializing data.
        tracker.load();
        Character character = selector.selectChar();
        activeText = character.getText();
    }

    //Iterates to the next night.
    void IterateNight()
    {

        this.nightCount++;
        //run conditions.
        this.UpdateNetWorth(100 + Random.Range(tracker.score/4 , tracker.score/2)); // Updates the bouncers net worth at the end of the night
    }
   
    void UpdateNetWorth(int Cash)
    {

        this.NetWorth += Cash;
    }
   
    void AcceptBribe(int Bribe)
    {

        UpdateNetWorth(Bribe);
    }

    //Will be called when a player clicks the "Admit" button.
    void Admit(Character character)
    {
        switch (character.Admit())
        {
            case 0:
                //TODO: Call tracker.MajorProblem() function.
                break;
            case 1:
                //TODO: Call tracker.MinorProblem() function.
                break;
            case 2:
                //TODO: Call tracker.MinorGood() function.
                break;
            case 3:
                //TODO: Call tracker.MajorGood() function.
                break;
        }

    }
    //Will be called when the player clicks the "Bounce" button.
    void Bounce(Character character)
    {
        switch (character.Bounce())
        {
            case 0:
                //TODO: Call tracker.MajorProblem() function.
                break;
            case 1:
                //TODO: Call tracker.MinorProblem() function.
                break;
            case 2:
                //TODO: Call tracker.MinorGood() function.
                break;
            case 3:
                //TODO: Call tracker.MajorGood() function.
                break;

        }
    }

    



    // Update is called once per frame
    void Update()
    {
     
        

    }
}


//DUMMY CLASSES PLEASE IGNORE
class CharacterSelector 
{
   public Character selectChar() { return new Character(); }
}
class Character
{
    public string getText() {
        return "";
    }
    //0 is MAJOR PROBLEM (-20), 1 is MINOR PROBLEM(-5), 2 is Minor GOOD(+5), 3 is Major Good(+20)
    public int Admit()
    {
        return 0;
    }
    public int Bounce()
    {
        return 0;
    }
}
//REMOVE ONCE PROPER ReputationTracker class has been made.
class ReputationTracker
{
    public void load()
    {

    }
}
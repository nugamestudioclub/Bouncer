using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int NightCount { get; private set; }
    public float GameTime { get; private set; }
    bool IsOutOfTime => false; // TODO
    public static readonly int TotalNights = 3;
    public bool IsLastNight => NightCount == TotalNights;



    [SerializeField]
    private Transform NpcSpawn;

    [SerializeField]
    private NPCSelector selector;
    private float characterTime = 0; // Tracks the time spent by 

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private PlayerDialogueView playerDialog;
    [SerializeField]
    private PlayerDialogueReplyView playerButtonsDialog;

    [SerializeField]
    private DialogueHandler handler;

    //TODO: Create ReputationTracker.cs script and implement the following functions:
    //MajorProblem(), MinorProblem(), MajorGood(), MinorGood() and load() which can be left empty.
    //Each function when called will apply changes to Rep.
    //Also note: ONCE YOU CREATE THIS CLASS delete the DUMMY CLASS of ReputationTracker in the bottom of this script.

    [SerializeField]
    private ReputationTracker tracker;

    public static GameManager instance;

    private NPC activeCharacter;
    private NPC activeNpc;

    private List<bool> conditionStates;


    private int messageCounter = 0;
    void Awake()
    {
        instance = this;
        conditionStates = MakeConditionStates();
        BeginNight();
    }

    private List<bool> MakeConditionStates()
    {
        int count = Enumerable.Max((int[])Enum.GetValues(typeof(Condition)));
        var conditionStates = new List<bool>(count);

        for (int i = 0; i < count; ++i)
            conditionStates.Add(false);

        return conditionStates;
    }

    public void BeginNight()
    {
        InitializeNextNpc();
    }

    public void InitializeNextNpc()
    {
        activeNpc = selector.SelectNPC();
        GameObject go = Instantiate(activeNpc.gameObject, NpcSpawn);
        activeNpc = go.GetComponent<NPC>();
        Debug.Log($"Npc is null: {activeNpc == null}");
    }

    public bool CheckCondition(Condition condition)
    {
        return conditionStates[(int)condition];
    }

    public void AdmitCurrentNpc()
    {
        Admit(activeNpc);
    }

    public void BounceCurrentNpc()
    {
        Bounce(activeNpc);
    }

    void Admit(NPC character)
    {
        tracker.AdjustReputation(character.Effect);
        EndCharacter();
    }

    void Bounce(NPC character)
    {
        tracker.AdjustReputation(character.Effect switch
        {
            RepEffect.MajorProblem => RepEffect.MajorGood,
            RepEffect.MinorProblem => RepEffect.MinorGood,
            RepEffect.MinorGood => RepEffect.MinorProblem,
            RepEffect.MajorGood => RepEffect.MajorProblem,
            _ => RepEffect.None
        });
        EndCharacter();
    }

    void EndCharacter()
    {
        Destroy(activeNpc.gameObject);
        if (tracker.IsReputationBad)
            EndGame();
        else if (IsOutOfTime || selector.IsLast())
            EndNight();
        else
            InitializeNextNpc();
    }


    void EndNight()
    {
        ++NightCount;
        GameTime = 0;
        if (IsLastNight)
            EndGame();
    }

    void EndGame()
    {
        //TODO: TRANSITION TO LEADERBOARD
    }


    void IterateChoice()
    {
        DialogueNode[] node = handler.GetLinkedNodes().ToArray();
        
        if (node[0].IsNPC)
        {
            this.loadNpcText(node);
        }
        else
        {
            this.loadPcText(node);
        }
    }

    void loadNpcText(DialogueNode[] node)
    {
        //TODO: Fix.
        playerDialog.Clear();
        playerDialog.Add(new TextMessage(1, node[0].Text));

        continueButton.gameObject.SetActive(true);

        
    }

    void loadPcText(DialogueNode[] node)
    {
        for (int i = 0; i <= 0; i++)
        {
            DialogueNode currentNode = node[i];
            string text = currentNode.Text;

            playerDialog.Add(new TextMessage(0, text));
        }
    }
    void Stormout()
    {

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

    float CharacterPatienceRemaining(NPC character)
    {
        return character.Patience - GetCharacterTime();
    }

    // Reset time for the next character in queue
    void ResetCharacterTime()
    {
        characterTime = 0;
    }

    void Update()
    {
        GameTime += Time.deltaTime;
    }

    private IEnumerator<WaitForSeconds> PaitienceTimer()
    {
        int localCounter = 0 + messageCounter;

        yield return new WaitForSeconds(this.activeCharacter.Patience);
        if (localCounter == messageCounter)
        {
            Stormout();
        }
    }
}

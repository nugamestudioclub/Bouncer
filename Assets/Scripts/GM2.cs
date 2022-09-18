using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GM2 : MonoBehaviour
{
    //Private Serialized
    [SerializeField]
    private NPCSelector selector;
    [SerializeField]
    private Transform NpcSpawn;
    [SerializeField]
    private DialogueHandler handler;

    //Private Non-Serialized
    private float GameTime = 0;
    private ScoreTracker tracker;
    private ConversationTracker convo;
    private Night night;



    void Start()
    {
        tracker = new ScoreTracker();
        night = new Night(selector,NpcSpawn);
        convo = new ConversationTracker(handler, tracker, night);

    }

    public void RunBounce(NPC character)
    {
        tracker.CalculateEffect(character, DecisionType.BOUNCE);
    }

    public void RunAdmit(NPC character)
    {
        tracker.CalculateEffect(character, DecisionType.ADMIT);
    }

    void Update()
    {

        convo.IterateTimer();
        GameTime += Time.deltaTime;
    }

}


class Night
{
    private NPC selected;
    public NPC Active { get { return this.selected; }}
    private NPCSelector selector;
    public Night(NPCSelector selector,Transform npcSpawn)
    {
        this.selected = selector.SelectNPC();
        GameObject go = MonoBehaviour.Instantiate(this.selected.gameObject, npcSpawn);
        this.selected = go.GetComponent<NPC>();
        Debug.Log($"Npc is null: {this.selected == null}");
        this.selector = selector;
    }

    public void NextPlayer()
    {
        this.selected = this.selector.SelectNPC();

    }


}

class ScoreTracker
{
    private int score;
    private int rep;
    private int money;
    public int Score { get { return this.score; } }
    public int Reputation { get { return this.rep; } }
    public int Money { get { return this.money; } }

    public ScoreTracker()
    {
        this.score = 0;
        this.rep = 0;
        this.money = 0;
    }

    public void EndNight()
    {
        this.money += Random.Range(rep / 4, rep / 2);
    }

    public void CalculateEffect(NPC character,DecisionType type)
    {
        switch (character.Effect)
        {
            case RepEffect.MajorGood:
                rep -= 20;
                break;
            case RepEffect.MinorGood:
                rep -= 5;
                break;
            case RepEffect.MinorProblem:
                rep += 5;
                break;
            case RepEffect.MajorProblem:
                rep += 20;
                break;
        }
    }

  
}

class ConversationTracker {

    private DialogueHandler handler;
    private float timer = 60;
    private bool isTimerRunning;
    private ScoreTracker tracker;
    private Night night;
    public ConversationTracker(DialogueHandler handler,ScoreTracker tracker,Night night)
    {
        this.handler = handler;
        timer = 60;
        isTimerRunning = false;
        StartTimer();
        this.tracker = tracker;
        this.night = night;
    }
    public void SetNight(Night night)
    {
        this.night = night;    
    }

    public void StartTimer()
    {
        this.isTimerRunning = true;
    }
    public void StopTimer()
    {
        this.isTimerRunning = false;
    }
    public void NextDialog()
    {
        DialogueNode[] node = handler.GetLinkedNodes().ToArray();
        if (node.Length != 0)
        {
            if (node[0].IsNPC)
            {
                //DISPLAY NPC "NEXT" BUTTON USING GUI ELEMENTS and DIALOG BOX


                //Restart Timer for Paitience
                ResetTimer();
            }
            else
            {
                //DISPLAY PLAYER DIALOG BUTTONS USING GUI ELEMENTS and DIALOG BOX

                //Restart Timer for Paitience
                ResetTimer();
            }
        }
    }
    public void IterateTimer()
    {
        if(this.isTimerRunning)
            this.timer -= Time.deltaTime;
        if(timer <= 0)
        {
            StormOut();
        }
    }
    public void ResetTimer()
    {
        this.timer = 60;
    }

    public void StormOut()
    {
        tracker.CalculateEffect(night.Active, DecisionType.BOUNCE);
    }

}

enum DecisionType {BOUNCE, ADMIT}

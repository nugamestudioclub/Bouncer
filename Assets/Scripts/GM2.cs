using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GM2 : MonoBehaviour {
	//Private Serialized
	[SerializeField]
	private NPCSelector[] selectors;
	[SerializeField]
	private Transform NpcSpawn;
	[SerializeField]
	private DialogueHandler handler;
	[SerializeField]
	private TMP_Text guiMoney;
	[SerializeField]
	private TMP_Text guiRep;
	[SerializeField]
	private TMP_Text guiNightCount;
	[SerializeField]
	private Image clockHandTimer;
	[SerializeField]
	private MusicManager musicManager;
	[SerializeField]
	private int maxNumNights = 3;
	[SerializeField]
	private NPCDialogueView npcDialogueView;
	[SerializeField]
	private PlayerDialogueView playerDialogueView;



	//Private Non-Serialized
	private float GameTime = 0;
	private ScoreTracker tracker;
	private ConversationTracker convo;
	private Night night;
	private Color handColor;
	private int curNight = 0;

	public static NPC ActiveNpc => instance.night.Active;
	public static GM2 instance;


	void Awake() {
		instance = this;
		tracker = new ScoreTracker();
		convo = new ConversationTracker(handler, tracker, night,
			npcDialogueView, playerDialogueView);
		handColor = clockHandTimer.color;

		BeginNight();
	}

	public void Bounce() {
		EndNpc();
		RunBounce(night.Active);
		//tracker.CalculateEffect(night.Active, DecisionType.BOUNCE);

	}
	public void Admit() {
		EndNpc();
		RunAdmit(night.Active);
		//tracker.CalculateEffect(night.Active, DecisionType.ADMIT);
	}

	public void RunBounce(NPC character) {
		tracker.CalculateEffect(character, DecisionType.BOUNCE);
		night.NextNpc();
		if( night.Active != null ) {
			convo.SetDialogue(night.Active.Dialogue);
			convo.NextDialog();
		}
	}

	public void RunAdmit(NPC character) {
		tracker.CalculateEffect(character, DecisionType.ADMIT);
		StartCoroutine(DoorOpenShut());
		night.NextNpc();
		if( night.Active != null ) {
			convo.SetDialogue(night.Active.Dialogue);
			convo.NextDialog();
		}
	}
	void EndNpc() {
		playerDialogueView.Clear();
		npcDialogueView.Clear();

		Destroy(night.Active.gameObject);
		if( tracker.IsRepBad )
			EndGame();
		else if( convo.Timer <= 0 || selectors[curNight].IsLast )
			EndNight();
	}

	void EndGame() {
		tracker.CalcaulteFinalScore();
		PlayerPrefs.SetInt("score", tracker.Score);
		SceneManager.LoadScene(2);
	}
	void EndNight() {
		EndGame();

		return; //

		curNight++;
		if( curNight < selectors.Length )
			BeginNight();
		else
			EndGame();
	}

	private void BeginNight() {
		night = new Night(selectors[curNight], NpcSpawn);
		convo.SetDialogue(night.Active.Dialogue);
		convo.NextDialog();
	}

	void Update() {
		guiMoney.text = "$" + tracker.Money.ToString();
		guiRep.text = "Rep:" + tracker.Reputation.ToString();
		guiNightCount.text = "Night:" + tracker.NightCount.ToString();

		float rotAngle = 90 + ((convo.Timer / 60) * 360);
		//TODO:Test this.
		clockHandTimer.gameObject.transform.localEulerAngles = new Vector3(clockHandTimer.transform.localEulerAngles.x,
			clockHandTimer.transform.localEulerAngles.y,
			rotAngle);
		if( convo.Timer < 60 / 4 ) {
			if( Mathf.RoundToInt(GameTime) % 2 == 0 ) {
				clockHandTimer.color = Color.red;
			}
			else {
				clockHandTimer.color = handColor;
			}

		}
		else {
			clockHandTimer.color = handColor;
		}


		convo.IterateTimer();
		GameTime += Time.deltaTime;
	}


	IEnumerator DoorOpenShut() {
		musicManager.openDoor();
		yield return new WaitForSeconds(3);
		musicManager.closeDoor();
	}

}


class Night {
	private NPC selected;
	public NPC Active { get { return this.selected; } }
	private NPCSelector selector;
	private Transform spawn;
	public Night(NPCSelector selector, Transform npcSpawn) {
		this.selected = selector.SelectNPC();
		GameObject go = MonoBehaviour.Instantiate(this.selected.gameObject, npcSpawn);
		this.selected = go.GetComponent<NPC>();
		Debug.Log($"Npc is null: {this.selected == null}");
		this.selector = selector;
		this.spawn = npcSpawn;
		this.selector = selector;
	}


	public void NextNpc() {
		if( selector.IsLast ) {
			selected = null;
		}
		else {
			this.selected = this.selector.SelectNPC();
			Debug.Log("Selected:" + this.selected.name);
			GameObject go = MonoBehaviour.Instantiate(this.selected.gameObject, this.spawn);
			this.selected = go.GetComponent<NPC>();
			Debug.Log($"Npc is null: {this.selected == null}");
		}

	}



}



class ConversationTracker {

	private DialogueHandler handler;
	private float timer = 60;
	private bool isTimerRunning;
	private ScoreTracker tracker;
	private Night night;
	private NPCDialogueView npcDialogueView;
	private PlayerDialogueView playerDialogueView;
	public float Timer { get { return Mathf.Clamp(this.timer, 0, 60); } }
	public ConversationTracker(DialogueHandler handler, ScoreTracker tracker, Night night,
		NPCDialogueView npcDialogueView, PlayerDialogueView playerDialogueView) {
		this.handler = handler;
		timer = 60;
		isTimerRunning = false;
		StartTimer();
		this.tracker = tracker;
		this.night = night;
		this.npcDialogueView = npcDialogueView;
		this.playerDialogueView = playerDialogueView;
	}
	public void SetNight(Night night) {
		this.night = night;
	}

	public void StartTimer() {
		isTimerRunning = true;
	}
	public void StopTimer() {
		isTimerRunning = false;
	}

	private static int GetId(bool isNpc) => isNpc ? 1 : 0;

	public void SetDialogue(NPCDialogue dialogue) {
		handler.SetCharacterDialogue(dialogue);

		var node = handler.GetCurrentNode();
		npcDialogueView.Add(MakeNpcTextMessage(node.Text, node.Emotion));
	}

	private TextMessage MakeNpcTextMessage(string text, Emotion emotion) {
		return MakeTextMessage(GetId(isNpc: true), text, onEmotion: Callback_SetNpcEmotion(emotion));
	}

	private TextMessage MakePlayerTextMessage(string text, DialogueNode nextNode) {
		var onReceive = nextNode == null ? null : Callback_SetCurrentNode(nextNode);
		return MakeTextMessage(GetId(isNpc: true), text, onReceive);
	}


	private UnityAction Callback_SetNpcEmotion(Emotion emotion) {
		return () => { GM2.ActiveNpc.ChangeEmotion(emotion);  };
	}

	private UnityAction Callback_SetCurrentNode(DialogueNode nextNode) {
		return () => { handler.SetCurrentNode(nextNode); NextDialog(); };
	}

	public static TextMessage MakeTextMessage(int id, string text, UnityAction onReceive = null, UnityAction onEmotion = null) {
		return new TextMessage(id, text, onReceive, onEmotion);
	}

	public void NextDialog() {
		playerDialogueView.Clear();

		var children = handler.GetLinkedNodes().ToList(); ;

		if( children.Count == 0 )
			return;

		if( children[0].IsNPC ) {
			playerDialogueView.Add(MakePlayerTextMessage("...", children[0]));
		}
		else {
			npcDialogueView.Clear();
			playerDialogueView.Clear();

			var currentNode = handler.GetCurrentNode();

			npcDialogueView.Add(MakeNpcTextMessage(currentNode.Text, currentNode.Emotion));

			foreach( var node in handler.GetLinkedNodes() ) {
				var nextNode = node.Connections.Count > 0 ? handler.GetNode(node.Connections[0]) : null;
				playerDialogueView.Add(MakePlayerTextMessage(node.Text, nextNode));
			}
		}

		ResetTimer();
	}
	public void IterateTimer() {
		if( isTimerRunning )
			timer -= Time.deltaTime;
		if( timer <= 0 ) {
			StormOut();
		}
	}
	public void ResetTimer() {
		timer = 60;
	}

	public void StormOut() {
		tracker.CalculateEffect(night.Active, DecisionType.BOUNCE);
	}

}

class ScoreTracker {
	private int score;
	private int rep;
	private int money;
	private int nightCount;
	public int Score { get { return score; } }
	public int Reputation { get { return rep; } }
	public int Money { get { return money; } }

	public int NightCount { get { return nightCount; } }
	public bool IsRepBad { get { return Reputation < 0; } }

	public ScoreTracker() {
		score = 0;
		rep = 0;
		money = 0;
	}

	public void EndNight() {
		money += Random.Range(rep / 4, rep / 2);
		nightCount += 1;

	}

	public void CalculateEffect(NPC character, DecisionType type) {
		switch( character.Effect ) {
		case RepEffect.MajorGood:
			rep += 20;
			break;
		case RepEffect.MinorGood:
			rep += 5;
			break;
		case RepEffect.MinorProblem:
			rep -= 5;
			break;
		case RepEffect.MajorProblem:
			rep -= 20;
			break;
		}
	}

	public int CalcaulteFinalScore() {
		score = Mathf.RoundToInt(Mathf.Lerp(rep, money, 0.5f));
		PlayerPrefs.SetInt("score", score);
		return Score;
	}
}

enum DecisionType { BOUNCE, ADMIT }

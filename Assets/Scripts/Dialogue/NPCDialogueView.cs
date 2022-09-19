using UnityEngine;

public class NPCDialogueView : TextMessageLayoutView {
	[SerializeField]
	private GameObject bubblePrefab;
	protected override void DoStart() {
		base.DoStart();

		//Add(new TextMessage(1, "howdy"));
	}

	protected override TextMessageView MakeView(TextMessage textMessage) {
		textMessage.OnEmotion();
		return Instantiate(bubblePrefab,transform.parent)
			.GetComponentInChildren<NPCDialogueEntryView>();
	}
}
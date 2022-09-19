using UnityEngine;

public class NPCDialogueView : TextMessageLayoutView {
	[SerializeField]
	private GameObject bubblePrefab;
	protected override void DoStart() {
		base.DoStart();

		Add(new TextMessage(1, "howdy"));
	}

	protected override GameObject View(TextMessage textMessage) {
		return bubblePrefab;
	}
}
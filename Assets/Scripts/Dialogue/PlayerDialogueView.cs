using UnityEngine;

public class PlayerDialogueView : TextMessageLayoutView {
	[SerializeField]
	private GameObject bubblePrefab;

	protected override void DoStart() {
		base.DoStart();

		// TODO: delete
		string[] replies = new string[] {"hello", "how are you", "sorry,  I have to go"};
		foreach( string reply in replies )
			Add(new TextMessage(0, reply));
	}

	protected override GameObject View(TextMessage textMessage) {
		return bubblePrefab;
	}
}
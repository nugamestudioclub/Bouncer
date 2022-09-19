using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueReplyView : TextMessageView {
	protected override void DoAwake() {
		base.DoAwake();
	}

	[field: SerializeField]
	public Button Button { get; private set; }
}
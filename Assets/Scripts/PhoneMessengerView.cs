using UnityEngine;

public class PhoneMessengerView : TextMessageLayoutView {
	[SerializeField]
	GameObject[] bubblePrefabs;

	protected override void DoStart() {
		base.DoStart();
	}

	protected override GameObject View(TextMessage textMessage) {
		return Instantiate(GetBubblePrefab(textMessage.SpeakerId), transform.parent);
	}

	private GameObject GetBubblePrefab(int id) {
		return bubblePrefabs[id % bubblePrefabs.Length];
	}
}
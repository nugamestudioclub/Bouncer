using System.Collections.Generic;
using UnityEngine;

public class TextMessageLayoutView : MonoBehaviour {
	[SerializeField]
	private GameObject[] textMessagePrefabs;

	private IEnumerable<TextMessage> textMessageProvider;

	void Start() {
		DoStart();
	}

	protected virtual void DoStart() {
		Render();
	}

	private IEnumerable<TextMessage> GetTempProvider() {
		string[] texts = { "hi", "hey\n'sup?\netc", "whatever" };
		int id = 0;

		foreach( string text in texts )
			yield return new TextMessage(this is PhoneMessengerView ? id++ % 2 : 0, text);
	}

	public void Add(TextMessage textMessage) {
		var obj = Instantiate(GetTextMessagePrefab(textMessage.SpeakerId), transform.parent);
		var view = obj.GetComponent<TextMessageView>();

		view.Text = textMessage.Text;

		StartCoroutine(view.Resize());

		obj.transform.SetParent(transform);
	}

	public void Clear() {
		foreach( Transform child in transform )
			Destroy(child.gameObject);
	}

	public void Render() {
		Clear();

		textMessageProvider = GetTempProvider(); /// TODO: replace

		foreach( var textMessage in textMessageProvider )
			Add(textMessage);
	}

	private GameObject GetTextMessagePrefab(int id) {
		return textMessagePrefabs[id + textMessagePrefabs.Length % textMessagePrefabs.Length];
	}
}
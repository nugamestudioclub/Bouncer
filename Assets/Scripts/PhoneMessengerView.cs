using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneMessengerView : MonoBehaviour {
	[SerializeField]
	private GameObject[] bubblePrefabs;

	private IEnumerable<TextMessage> textMessageProvider;

	public void Render() {
		Clear();

		textMessageProvider = GetTempProvider();

		foreach( var textMessage in textMessageProvider )
			Add(textMessage);
	}

	void Start() {
		Render();
	}

	private IEnumerable<TextMessage> GetTempProvider() {
		string[] texts = { "hi", "hey\n'sup?\netc", "whatever" };
		int id = 0;

		foreach( string text in texts )
			yield return new TextMessage(id++ % 2, text);
	}

	public void Add(TextMessage textMessage) {
		var obj = Instantiate(GetBubblePrefab(textMessage.SpeakerId), transform.parent);
		var view = obj.GetComponent<PhoneTextMessageView>();
		var rect = obj.GetComponent<RectTransform>();

		view.Text = textMessage.Text;

		StartCoroutine(view.Resize());
		obj.transform.parent = transform;
	}

	public void Clear() {
		foreach( Transform child in transform )
			Destroy(child.gameObject);
	}

	private GameObject GetBubblePrefab(int id) {
		return bubblePrefabs[id + bubblePrefabs.Length % bubblePrefabs.Length];
	}
}
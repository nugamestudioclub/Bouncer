using System.Collections.Generic;
using UnityEngine;

public abstract class TextMessageLayoutView : MonoBehaviour {
	void Start() {
		DoStart();
	}

	protected virtual void DoStart() {	}

	protected abstract GameObject View(TextMessage textMessage);

	public void Add(TextMessage textMessage) {
		var obj = Instantiate(View(textMessage), transform.parent);
		var view = obj.GetComponent<TextMessageView>();

		view.Text = textMessage.Text;

		StartCoroutine(view.Resize());

		obj.transform.SetParent(transform);
	}

	public void Clear() {
		foreach( Transform child in transform )
			Destroy(child.gameObject);
	}
}
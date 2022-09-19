using System.Collections.Generic;
using UnityEngine;

public abstract class TextMessageLayoutView : MonoBehaviour {
	void Start() {
		DoStart();
	}

	protected virtual void DoStart() {	}

	protected abstract TextMessageView MakeView(TextMessage textMessage);

	public void Add(TextMessage textMessage) {

		var view = MakeView(textMessage);

		view.Text = textMessage.Text;

		StartCoroutine(view.Resize());

		view.transform.SetParent(transform);
	}

	public void Clear()
    {
		foreach (Transform child in transform)
		{ 
			Debug.Log(child.gameObject.name);
			Destroy(child.gameObject);
		}

        
	}
}
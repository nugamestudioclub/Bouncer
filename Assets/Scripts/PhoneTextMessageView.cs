using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections;

public class PhoneTextMessageView : MonoBehaviour {
	[SerializeField]
	private TMP_Text textMesh;

	private RectTransform myRect;

	private RectTransform childRect;

	private void Awake() {
		myRect = GetComponent<RectTransform>();
		childRect = textMesh.gameObject.GetComponent<RectTransform>();

	}

	public string Text {
		get => textMesh.text;
		set {
			textMesh.text = value;
			Debug.Log($"{textMesh.gameObject.name} size: {childRect.sizeDelta}");
		}
	}

	public IEnumerator Resize() {
		yield return new WaitForSeconds(0.1f);
		Debug.Log($"{gameObject.name} size: {myRect.sizeDelta}");
		myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, childRect.rect.height);
		Debug.Log($"{gameObject.name} new size: {myRect.sizeDelta}");
		childRect.transform.localPosition = new Vector3(
			childRect.transform.localPosition.x,
			0.0f,
			childRect.transform.localPosition.z
		);
	}

	public Vector2 Size => myRect.sizeDelta;
}
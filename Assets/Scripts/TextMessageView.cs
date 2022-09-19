using UnityEngine;
using TMPro;
using System.Collections;

public class TextMessageView : MonoBehaviour {
	[SerializeField]
	private TMP_Text textMesh;

	private RectTransform myRect;

	private RectTransform childRect;

	[SerializeField]
	private bool scaleHorizontally;

	[SerializeField]
	private bool scaleVertically;

	private void Awake() {
		DoAwake();
	}

	protected virtual void DoAwake() {
		myRect = GetComponent<RectTransform>();
		childRect = textMesh.gameObject.GetComponent<RectTransform>();
	}

	public string Text {
		get => textMesh.text;
		set => textMesh.text = value;
	}

	public Vector2 Size => myRect.sizeDelta;

	public IEnumerator Resize() {
		yield return new WaitForSeconds(0.1f);

		if( scaleHorizontally )
			myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, childRect.rect.width);
		if( scaleVertically )
			myRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, childRect.rect.height);

		childRect.transform.localPosition = new Vector3(
			0.0f,
			0.0f,
			childRect.transform.localPosition.z
		);
	}
}
using System.Collections.Generic;
using UnityEngine;

public class IdCardView : MonoBehaviour {
    private GameObject idCardPrefab;
    void Start() {
		DoStart();
	}

	protected virtual void DoStart() {
		Render();
	}

    public void Render() {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clic : MonoBehaviour {
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ClicHappened();
		}
	}

	void ClicHappened() {
		Vector3	mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
		if (hit) {
			WhatIsHit(hit);
		}
	}

	void WhatIsHit(RaycastHit2D hit) {
		GameObject hitObject = hit.collider.gameObject;

		string tag = hitObject.tag;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject gameManager;

	public bool isMenuActive;
	public bool changingMenuActiveness;

	void Start () {
		changingMenuActiveness = true;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isMenuActive = !isMenuActive;
			changingMenuActiveness = true;
		}
		if (changingMenuActiveness) {
			if (isMenuActive) {
				gameManager.GetComponent<gameManager>().pause(true);
			}
			else {
				gameManager.GetComponent<gameManager>().pause(false);
			}
			transform.GetChild(0).gameObject.SetActive(isMenuActive);
			changingMenuActiveness = false;
		}	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
	public string whichCharacter;

	private static bool isJohn;
	private static bool isThomas;
	private static bool isClaire;

	void Update() {
		if (isJohn && isClaire && isThomas) {
			isJohn = false;
			isThomas = false;
			isClaire = false;
			Debug.Log("You won !");
			if (SceneManager.GetActiveScene().buildIndex == 0)
				SceneManager.LoadScene(1);
			else
				SceneManager.LoadScene(0);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.name == "John" && collider.gameObject.name == whichCharacter)
			isJohn = true;
		if (collider.gameObject.name == "Thomas" && collider.gameObject.name == whichCharacter)
			isThomas = true;
		if (collider.gameObject.name == "Claire" && collider.gameObject.name == whichCharacter)
			isClaire = true;
			
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.name == "John" && collider.gameObject.name == whichCharacter)
			isJohn = false;
		if (collider.gameObject.name == "Thomas" && collider.gameObject.name == whichCharacter)
			isThomas = false;
		if (collider.gameObject.name == "Claire" && collider.gameObject.name == whichCharacter)
			isClaire = false;
	}
}

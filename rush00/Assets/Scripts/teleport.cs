using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour {

	public string	map;
	// Use this for initialization

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Enter");
		SceneManager.LoadScene(map);
	}
}

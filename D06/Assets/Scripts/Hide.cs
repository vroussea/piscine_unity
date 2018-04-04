using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter(Collider collider) {
		player.GetComponent<CharacterControl>().isHidden = true;
    }

	void OnTriggerExit(Collider collider) {
		player.GetComponent<CharacterControl>().isHidden = false;
    }
}

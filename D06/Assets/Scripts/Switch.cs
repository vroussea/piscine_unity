using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	private AudioSource audioSource;
	public GameObject door;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public void openDoor() {
		door.GetComponent<MeshRenderer>().enabled = false;
		door.GetComponent<MeshCollider>().enabled = false;
		audioSource.Play();
	}
}

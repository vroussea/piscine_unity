using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour {

	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public void pickKey() {
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		audioSource.Play();
	}
}

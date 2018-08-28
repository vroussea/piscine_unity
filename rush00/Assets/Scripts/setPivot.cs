using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPivot : MonoBehaviour {

	public GameObject	pivot;

	private Rigidbody2D	rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		rb.centerOfMass = pivot.transform.localPosition;
	}
}

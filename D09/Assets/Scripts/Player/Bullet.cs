using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public float duration;

	private Rigidbody rigidbody;

	void Start() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddForce(transform.forward * speed);
	}

	void Update () {
		Destroy(gameObject, duration);
	}

	void OnCollisionExit(Collision collision)
    {
        Destroy(gameObject);
    }
}

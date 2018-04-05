using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed;
	public float rotateSpeed;

	private Rigidbody rb;

	public float boost;

	public Vector3 rotationVelocity;

	void Start() {
		boost = 100;
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		Vector3 move = (transform.forward * Input.GetAxis("Vertical")).normalized;

		move *= speed;

        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

		rotationVelocity = rb.angularVelocity;
		rb.angularVelocity = new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0).normalized * rotateSpeed;

		float	boostTrigger = Input.GetAxis("Shift");
		if (boostTrigger != 0 && boost >= 1) {
			move *= 3;
			boost--;
		}
		if (boostTrigger == 0 && boost < 100) {
			boost++;
		}

		move.y = rb.velocity.y;
		rb.velocity = move;
	}
}

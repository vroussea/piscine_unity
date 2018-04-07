using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;

	private CharacterController controller;

	void Start () {
		controller = GetComponent<CharacterController>();		
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= (speed + Input.GetAxis("Shift") * speed);
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {
	public GameObject	character;
	private Rigidbody2D	characterBody;
	public int			jumpHeight;
	public bool			isMain;
	public int			speed;
	public Vector3		velocity;

	void Start() {
		speed = 8;
	}

	void Update () {
		characterBody = character.GetComponent<Rigidbody2D>();
		if (isMain) {
			characterBody.constraints = RigidbodyConstraints2D.None;
			characterBody.constraints = RigidbodyConstraints2D.FreezeRotation;
			movement();
		}
		else {
			characterBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}
	}

	public void setMain(bool value) {
		isMain = value;
	}

	void movement() {
		if (Input.GetKey(KeyCode.RightArrow)) {
    	    characterBody.velocity = new Vector2 (speed, characterBody.velocity.y);
    	} 
    	else if(Input.GetKeyUp(KeyCode.RightArrow)){
    		characterBody.velocity = new Vector2(0, characterBody.velocity.y);
		}
    	if (Input.GetKey(KeyCode.LeftArrow)) {
			characterBody.velocity = new Vector2 (-speed , characterBody.velocity.y);
    	} 
    	else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
    	    characterBody.velocity = new Vector2(0, characterBody.velocity.y);
    	}
		if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
			characterBody.velocity = new Vector2(0, characterBody.velocity.y);
		if (Input.GetKeyDown("space") && (Math.Abs(characterBody.velocity.y) < 0.01f)) {
			characterBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
		}

		velocity = characterBody.velocity;
	}
}

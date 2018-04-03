using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	private CharacterController controller;

	public float speed;
	private float actualSpeed;

	public float speedCam;

	public GameObject gameManager;

	private Raycast3D raycast;

	void Start () {
		raycast = GetComponent<Raycast3D>();
		controller = GetComponent<CharacterController>();
		Cursor.visible = false;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) {
			actualSpeed = 2 * speed;
			gameManager.GetComponent<GameManager>().discretion += 1f;
			gameManager.GetComponent<GameManager>().run = true;
		}
		else {
			actualSpeed = speed;
			gameManager.GetComponent<GameManager>().run = false;
			
		}
		move();
		moveCamera();
	}

	void move() {
		if (Input.GetKey(KeyCode.W)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.forward) * actualSpeed);
		}
		if (Input.GetKey(KeyCode.S)) {
        	controller.SimpleMove(-transform.TransformDirection(Vector3.forward) * actualSpeed);
		}
		if (Input.GetKey(KeyCode.A)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.left) * actualSpeed);
		}
		if (Input.GetKey(KeyCode.D)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.right) * actualSpeed);
		}
	}

	void moveCamera() {
		float dir_x = transform.localEulerAngles.x;
		float dir_y = transform.localEulerAngles.y;

		transform.eulerAngles = new Vector3(dir_x - Input.GetAxis("Mouse Y") * speedCam, dir_y + Input.GetAxis("Mouse X") * speedCam, 0);
	}

	void OnTriggerEnter(Collider collider) {
		gameManager.GetComponent<GameManager>().seen = true;
    }

	void OnTriggerExit(Collider collider) {
		gameManager.GetComponent<GameManager>().seen = false;
    }

	void OnTriggerStay(Collider collider) {
		string[] obstacle = {"walls"};
		Vector3 lightPosition = collider.transform.position;
        if (collider.gameObject.tag == "light" && raycast.CastRayIsObstacle(lightPosition, transform.position - lightPosition, 100f, "player", obstacle)) {
			gameManager.GetComponent<GameManager>().discretion += 1f;
		}
		else {
			gameManager.GetComponent<GameManager>().seen = false;
		}
    }
}

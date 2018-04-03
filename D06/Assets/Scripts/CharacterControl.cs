using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	private CharacterController controller;

	public float speed;

	public float speedCam;

	public GameObject gameManager;

	private Raycast3D raycast;

	void Start () {
		raycast = GetComponent<Raycast3D>();
		controller = GetComponent<CharacterController>();
		Cursor.visible = false;
	}
	
	void Update () {
		move();
		moveCamera();
	}

	void move() {
		if (Input.GetKey(KeyCode.W)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.forward) * speed);
		}
		if (Input.GetKey(KeyCode.S)) {
        	controller.SimpleMove(-transform.TransformDirection(Vector3.forward) * speed);
		}
		if (Input.GetKey(KeyCode.A)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.left) * speed);
		}
		if (Input.GetKey(KeyCode.D)) {
        	controller.SimpleMove(transform.TransformDirection(Vector3.right) * speed);
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
		gameManager.GetComponent<GameManager>().seen = false;;
    }

	void OnTriggerStay(Collider collider) {
		gameManager.GetComponent<GameManager>().discretion++;
		string[] obstacle = {"lights"};
		Vector3 lightPosition = collider.transform.position;
        if (collider.gameObject.tag == "light" && raycast.CastRayIsObstacle(lightPosition, transform.position - lightPosition, 10, "player", obstacle)) {
			gameManager.GetComponent<GameManager>().discretion += 0.5f;
		}
    }
}

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

	public bool isHidden;

	private AudioSource audioSource;

	public bool key;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		raycast = GetComponent<Raycast3D>();
		controller = GetComponent<CharacterController>();
		Cursor.visible = false;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) {
			if (!audioSource.isPlaying) {
				audioSource.loop = true;
        		audioSource.Play();
			}
			actualSpeed = 2 * speed;
			gameManager.GetComponent<GameManager>().discretion += 0.75f;
			gameManager.GetComponent<GameManager>().run = true;
		}
		else {
			audioSource.Stop();
			actualSpeed = speed;
			gameManager.GetComponent<GameManager>().run = false;
			
		}
		move();
		moveCamera();
		useItem();
	}

	void useItem() {
		if (Input.GetKeyDown("e")) {
			Transform camera = transform.GetChild(0).transform;
			RaycastHit hit = raycast.CastRay(camera.position, transform.TransformDirection(Vector3.forward), 1f);
			if (hit.collider && hit.distance < 1.5f) {
				Collider collider = hit.collider;
				Debug.Log(collider.name);				
				if (collider.name == "prop_keycard_card") {
					key = true;
					collider.gameObject.GetComponent<KeyCard>().pickKey();
				}
				if (collider.name == "prop_keycard_card") {
					key = true;
					collider.gameObject.GetComponent<KeyCard>().pickKey();
				}
				if (collider.name == "prop_keycard_card") {
					key = true;
					collider.gameObject.GetComponent<KeyCard>().pickKey();
				}
			}
		}
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
        if (raycast.CastRayIsObstacle(lightPosition, transform.position - lightPosition, 100f, "player", obstacle)) {
			if (collider.gameObject.tag == "light" ) {
				gameManager.GetComponent<GameManager>().discretion += (isHidden ? 0.25f : 0.75f);
			}
			if (collider.gameObject.tag == "camera" ) {
				gameManager.GetComponent<GameManager>().discretion += (isHidden ? 0.5f : 2.5f);
			}
		}
		else {
			gameManager.GetComponent<GameManager>().seen = false;
		}
    }
}

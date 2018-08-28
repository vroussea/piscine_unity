using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public float		speed;
	public float		walk;

	private Rigidbody2D	_rb;
	private GameObject	_camera;
	private Animator	_anim;

	private AudioSource audioSource;

	public AudioClip deathSound;
	public AudioClip loseSound;

	public bool lost;
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		_camera = GameObject.Find("Main Camera");
		_rb = GetComponent<Rigidbody2D>();
		_anim = GetComponentInChildren<Animator>();
	}
	
	void Update () {
		if (!lost) {
			Move();
			Rotate();
			CameraFollow();
			Animation();
		}
	}

	void Rotate() {
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - mouse);
	}

	void Move() {
		if (Input.GetKey("w"))
			_rb.AddForce(Vector2.up * speed);
		if (Input.GetKey("a"))
			_rb.AddForce(Vector2.left * speed);
		if (Input.GetKey("d"))
			_rb.AddForce(Vector2.right * speed);
		if (Input.GetKey("s"))
			_rb.AddForce(Vector2.down * speed);
	}

	void CameraFollow() {
		_camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("EnnemyShoot")) {
			audioSource.PlayOneShot(deathSound);
			audioSource.PlayOneShot(loseSound);
			lost = true;
			gameObject.GetComponent<Collider2D>().enabled = false;
			Destroy(coll.gameObject);
		}
    }

	void Animation() {
		Vector2 velocityTmp = new Vector2(_rb.velocity.x * _rb.velocity.x, _rb.velocity.y * _rb.velocity.y);
		bool walkTmp = (velocityTmp.x > walk || velocityTmp.y > walk);

		if (_anim.GetBool("walk") != walkTmp)
			_anim.SetBool("walk", walkTmp);
	}
}

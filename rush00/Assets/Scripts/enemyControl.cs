using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour {

	public GameObject	weaponObject;
	private Weapon weapon;
	public float	speed;
	public float	distancePoursuit;

	private Vector3		_target;
	public bool		_follow;
	private Animator	_anim;

	private AudioSource audioSource;

	public AudioClip deathSound;

	private Raycast raycast;

	public SpriteRenderer[] _sprites;


	void Start () {
		raycast = GetComponent<Raycast>();
		audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
		weapon = weaponObject.GetComponent<Weapon>();
		weapon.gameObject.GetComponent<SpriteRenderer>().enabled = false;		
		weapon.isEnnemy = true;
		_follow = false;
		_anim = GetComponentInChildren<Animator>();
		_sprites = GetComponentsInChildren<SpriteRenderer>();
		_sprites[3].sprite = weapon.weaponSprite;
	}
	
	void Update () {
		weapon.isEquipped = true;
		if (_follow) {
			weapon.wantsToFire = true;
			if (Vector2.Distance(transform.position, _target) > distancePoursuit) {
				MoveTo(_target);
			}
			else {
				_anim.SetBool("walk", false);
				weapon.wantsToFire = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			Vector3 posPlayer = other.gameObject.transform.position;
			if (raycast.CastRayIsObstacle(transform.position, posPlayer - transform.position, "Player", "Walls")) {
				_follow = true;			
				_target = other.gameObject.transform.position;
				weapon.target = _target;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("PlayerShoot")) {
			audioSource.PlayOneShot(deathSound);
            Destroy(gameObject);
			Destroy(coll.gameObject);
		}
    }

	void MoveTo(Vector3 target) {
		if (!_anim.GetBool("walk"))
			_anim.SetBool("walk", true);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - _target);
		transform.position = Vector2.MoveTowards(transform.position, _target, Time.deltaTime * speed);
	}
}

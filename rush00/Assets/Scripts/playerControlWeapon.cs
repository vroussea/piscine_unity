using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlWeapon : MonoBehaviour {

	private Raycast raycast;
	public Weapon weapon;
	public SpriteRenderer[] _sprites;
	private Rigidbody2D	_weapon_rb;

	public AudioClip takeWeaponSound;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		raycast = GetComponent<Raycast>();
		_sprites = GameObject.Find("Player").GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<playerControl>().lost) {
			getWeapon();
			dumpWeapon();
		}
		else {
			if (weapon)
				weapon.isEquipped = false;
		}
	}

	void getWeapon() {
		if (!weapon && Input.GetKeyDown("e")) {
			Vector3 rayStartPos = transform.position;
			rayStartPos.z = -10;
			Collider2D collider = raycast.CastRaySearch(rayStartPos, Vector2.zero, "Weapon");
			if (collider) {
				audioSource.PlayOneShot(takeWeaponSound);
				weapon = collider.gameObject.GetComponent<Weapon>();
				weapon.isEquipped = true;
				weapon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				weapon.transform.parent = gameObject.transform;
				_sprites[3].sprite = weapon.weaponSprite;
			}
		}
	}

	void dumpWeapon() {
		if (weapon && Input.GetMouseButtonDown(1)) {
			weapon.transform.parent = null;
			_sprites[3].sprite = null;			
			weapon.GetComponent<SpriteRenderer>().enabled = true;
			weapon.isEquipped = false;
			_weapon_rb = weapon.GetComponent<Rigidbody2D>();
			throwWeapon();
			weapon = null;
		}
	}

	void throwWeapon() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;
		Vector3 direction = mousePosition - transform.position;
		weapon.transform.position = transform.position;
		_weapon_rb.AddTorque(160, ForceMode2D.Force);
		_weapon_rb.AddForce(direction * 180);
	}
}

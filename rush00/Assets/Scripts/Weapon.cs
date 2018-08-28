using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour {
	public enum automatic
	{
		no,
		yes,
		semi
	};

	public bool isEquipped;
	public bool isMelee;
	public automatic isAutomatic;
	public int ammoCount;
	public GameObject bullet;
	public float rapidFireRate;
	public int rapidFireBullets;
	public bool isEnnemy;
	public bool wantsToFire;

	public Sprite weaponSprite;

	public Vector3 target;

	public float fireRate;

	private int rapidFireBulletsStack;
	
	private float timer;

	private float rapidFireTimer;

	public AudioClip shootSound;
	public AudioClip noAmmo;
	private AudioSource audioSource;

	void Start () {
		isEquipped = false;
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		timer += Time.deltaTime;
		nonAutomaticShoot();
		automaticShoot();
		semiAutomaticShoot();
		moveWeapon();
	}

	void nonAutomaticShoot() {
		if (isAutomatic == automatic.no && isEquipped && ((Input.GetMouseButtonDown(0) && !isEnnemy) || wantsToFire)) {
			if (timer > fireRate) {
				if ((!isMelee && (ammoCount > 0 || isEnnemy)) || isMelee) {
					shootOneTime();
					timer = 0;
				}
				else {
					fireRate = 0;
					audioSource.PlayOneShot(noAmmo);			
				}
			}
		}
	}

	void automaticShoot() {
		if (isAutomatic == automatic.yes && isEquipped && ((Input.GetMouseButton(0) && !isEnnemy) || wantsToFire)) {
			if (timer > fireRate) {
				if ((!isMelee && (ammoCount > 0 || isEnnemy)) || isMelee) {
					shootOneTime();
					timer = 0;
				}
				else {
					timer = 0;
					audioSource.PlayOneShot(noAmmo);			
				}
			}
		}
	}

	void semiAutomaticShoot() {
		if (isAutomatic == automatic.semi) {
			rapidFireTimer += Time.deltaTime;
			if (rapidFireBulletsStack > 0 && rapidFireTimer > rapidFireRate) {
				shootOneTime();
				rapidFireBulletsStack--;
				rapidFireTimer = 0;
			}
			if (isEquipped && ((Input.GetMouseButtonDown(0) && !isEnnemy) || wantsToFire)) {
				if (timer > fireRate) {
					if ((!isMelee && (ammoCount > 0 || isEnnemy)) || isMelee) {
						audioSource.PlayOneShot(shootSound);
						rapidFireBulletsStack = 3;
						timer = 0;
					}
					else {
						fireRate = 0;
						audioSource.PlayOneShot(noAmmo);			
					}
				}
			}
		}
	}

	void shootOneTime() {
		if (!isMelee)
			ammoCount--;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;
		Vector3 direction = targetPos(mousePosition) - transform.position;	
		GameObject shoot = Instantiate(bullet, transform.position + (isMelee ? 0.5f : 1) * Vector3.Normalize(direction), Quaternion.identity);
        float alpha = (float)Math.Atan2(direction.y, direction.x);
		shoot.GetComponent<shoot>().setDir(direction);
		shoot.transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha);
		shoot.layer = (isEnnemy ? LayerMask.NameToLayer("EnnemyShoot") : LayerMask.NameToLayer("PlayerShoot"));
		if (isAutomatic != automatic.semi)
			audioSource.PlayOneShot(shootSound);
	}

	Vector3 targetPos(Vector3 mousePosition) {
		return (isEnnemy ? target : mousePosition);
	}

	void moveWeapon() {
		if (isEquipped) {
			transform.position = transform.parent.position;
		}
	}
}
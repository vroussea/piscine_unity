using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Footman : MonoBehaviour {

	public Vector3	targetPosition;
	public float	moveSpeed;

	private Animator animatorComponent;

	private SpriteRenderer renderer;

	void Start () {
        renderer = GetComponent<SpriteRenderer>();
		
		targetPosition = transform.position;
		animatorComponent = GetComponent<Animator>();
	}
	
	void Update () {

		if (Vector3.Distance(transform.position, targetPosition) < 0.01f) {
			animatorComponent.Play("standing");
		} else {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		}
	}

	public void Move(Vector3 pos) {
		GetComponent<AudioSource>().Play();

		Vector3 direction = pos - transform.position;
		targetPosition = pos;
		string animationName = "standing";

		if (direction.x < 0) {
			// GAUCHE

			if (direction.y > 0) {
				// HAUT GAUCHE

				if (direction.y > -direction.x) {
					animationName = "moveUp";
				} else {
					animationName = "moveLeft";
				}

			} else {
				// BAS GAUCHE

				if (-direction.y > -direction.x) {
					animationName = "moveDown";
				} else {
					animationName = "moveLeft";
				}

			}

		} else {
			// DROITE

			if (direction.y > 0) {
				// HAUT DROITE

				if (direction.y > direction.x) {
					animationName = "moveUp";
				} else {
					animationName = "moveRight";
				}

			} else {
				// BAS DROITE

				if (-direction.y > direction.x) {
					animationName = "moveDown";
				} else {
					animationName = "moveRight";
				}

			}

		}

		animatorComponent.Play(animationName);
	}

	public void setActive() {
        renderer.color = Color.blue;
	}

	public void setNotActive() {
		renderer.color = Color.white;
	}
}
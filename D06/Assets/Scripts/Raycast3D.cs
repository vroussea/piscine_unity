﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast3D : MonoBehaviour {
public bool CastRay(Vector3 pos, Vector3 dir, float length) {
		return Physics.Raycast(pos, dir, length);
	}

	public Collider CastRaySearch(Vector3 pos, Vector3 dir, string tag, float length) {
		RaycastHit[] hits = Physics.RaycastAll(pos, dir, length);
		foreach(RaycastHit hit in hits) {
			Collider collider = hit.collider;
			if (collider.gameObject.tag == tag) {
				return collider;
			}
		}
		return null;
	}

	public bool CastRayIsObstacle(Vector3 pos, Vector3 dir, float length, string search, string[] obstacles) {
		float closestObstacle = 1000;
		float playerDistance = -1;
		RaycastHit[] hits = Physics.RaycastAll(pos, dir, length);
		if (hits.Length <= 0)
			return false;
		foreach(RaycastHit hit in hits) {
			Collider collider = hit.collider;
			if (collider.gameObject.tag == search) {
				playerDistance = hit.distance;
			}
			else {
				foreach (string obstacle in obstacles) {
					if (collider.gameObject.tag == obstacle) {
						closestObstacle = hit.distance;
					}
				}
			}
			if (playerDistance != -1 && playerDistance >= closestObstacle)
				return false;
		}
		if (playerDistance != -1 && playerDistance >= closestObstacle)
				return false;
		return true;
	}
}

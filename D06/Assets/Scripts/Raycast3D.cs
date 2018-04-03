using System.Collections;
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

	public Collider CastRayIsObstacle(Vector3 pos, Vector3 dir, float length, string search, string[] obstacles) {
		RaycastHit[] hits = Physics.RaycastAll(pos, dir, length);
		foreach(RaycastHit hit in hits) {
			Collider collider = hit.collider;
			if (collider.gameObject.tag == search) {
				return collider;
			}
			foreach (string obstacle in obstacles) { 
				if (collider.gameObject.tag == obstacle) {
					return null;
				}
			}
		}
		return null;
	}
}

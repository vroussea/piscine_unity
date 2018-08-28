using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {
	public Collider2D CastRay(Vector3 pos, Vector3 dir) {
		RaycastHit2D hit = Physics2D.Raycast(pos, dir);
		if (hit) {
			return hit.collider;
		}
		return null;
	}

	public Collider2D CastRaySearch(Vector3 pos, Vector3 dir, string tag) {
		RaycastHit2D[] hits = Physics2D.RaycastAll(pos, dir);
		foreach(RaycastHit2D hit in hits) {
			Collider2D collider;
			if (hit) {
				collider = hit.collider;
				if (collider.gameObject.tag == tag) {
					return collider;
				}
			}
			else
			{
				return null;
			}
		}
		return null;
	}

	public Collider2D CastRayIsObstacle(Vector3 pos, Vector3 dir, string search, string obstacle) {
		RaycastHit2D[] hits = Physics2D.RaycastAll(pos, dir);
		foreach(RaycastHit2D hit in hits) {
			Collider2D collider;
			if (hit) {
				collider = hit.collider;
				if (collider.gameObject.tag == search) {
					return collider;
				}
				if (collider.gameObject.tag == obstacle) {
					return null;
				}
			}
			else
			{
				return null;
			}
		}
		return null;
	}
}

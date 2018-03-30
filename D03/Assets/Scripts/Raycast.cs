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
}

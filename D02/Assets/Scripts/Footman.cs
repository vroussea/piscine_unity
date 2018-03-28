using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour {

	public Vector3	targetPosition;
	private float	step;

	void Start () {
		step = 0.05f;
	}
	
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
	}

	public void Move(Vector3 pos) {
		targetPosition = pos;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public GameObject cube;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range(0.08f, 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		cube.transform.Translate(new Vector3(0, -speed, 0));
	}

	public float sayPosY() {
		return cube.transform.position.y;
	}
}

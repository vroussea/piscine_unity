using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	private GameObject camera;
	private GameObject gunpoint;
	private Raycast raycast;

	public GameObject bullet;

	void Start () {
		camera = GameObject.Find("Character/Camera");
		gunpoint = GameObject.Find("weapon/gunpoint");
		raycast = GetComponent<Raycast>();
	}
	
	void Update () {
		RaycastHit hit = raycast.CastRay(camera.transform.position, camera.transform.forward, 1000f);
		Debug.DrawLine(gunpoint.transform.position, hit.point, Color.blue);
		if (Input.GetAxis("Fire1") != 0)
			GameObject.Instantiate(bullet, gunpoint.transform.position, Quaternion.LookRotation(hit.point - gunpoint.transform.position, transform.up));
	}
}

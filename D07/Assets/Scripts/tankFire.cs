using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankFire : MonoBehaviour {

	private RayCast rayCast;

	public GameObject gunHit;
	public GameObject canonHit;

	void Start () {
		rayCast = GetComponent<RayCast>();
	}
	
	void Update () {
		float mouse0 = Input.GetAxis("Fire1");
		if (mouse0 != 0) {
			RaycastHit hit =  rayCast.CastRay(transform.GetChild(0).position, transform.GetChild(0).position - transform.position, 100f);
			if (hit.collider) {
				Debug.Log(hit.collider.tag);
				Debug.DrawLine(transform.GetChild(0).position, hit.collider.transform.position, Color.blue);
				Instantiate(gunHit, hit.collider.transform);
			}
		}
	}
}

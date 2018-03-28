using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmenManager : MonoBehaviour {

	public List<Footman> footmen = new List<Footman>();

	void Start () {
		GameObject[] startingFootmen = GameObject.FindGameObjectsWithTag("footman");
		foreach (GameObject footman in startingFootmen) {
			footmen.Add(footman.GetComponent<Footman>());
		}
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0;
			foreach(Footman footman in footmen) {
				footman.Move(pos);
			}
		}
	}
}

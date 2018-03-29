using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmenManager : MonoBehaviour {

	public List<Footman> footmen = new List<Footman>();
	public Vector3 pos;
	public Vector3 dirRay;

	void Start () {
		//GameObject[] startingFootmen = GameObject.FindGameObjectsWithTag("footman");
		//foreach (GameObject footman in startingFootmen) {
		//	footmen.Add(footman.GetComponent<Footman>());
		//}
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			foreach (Footman footman in footmen) {
				footman.setNotActive();
			}
			footmen.Clear();
		}
		if (Input.GetMouseButtonDown(0)) {
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			dirRay = pos;
			dirRay.z = 0;

			dirRay = dirRay - pos;

			RaycastHit2D hit;

			if ((hit = Physics2D.Raycast(pos, dirRay))) {
				if (hit.collider.tag == "footman") {
					if (!Input.GetKey(KeyCode.LeftControl)) {
						foreach (Footman footman in footmen) {
							footman.setNotActive();
						}
						footmen.Clear();
					}
					Footman newFootman = hit.collider.gameObject.GetComponent<Footman>();
					newFootman.setActive();
					footmen.Add(newFootman);
				}
			}
			else {
				commandMove(pos);
			}


		}
	}

	void commandMove(Vector3 pos) {
			pos.z = -2;
			foreach(Footman footman in footmen) {
				footman.Move(pos);
			}
	}
}

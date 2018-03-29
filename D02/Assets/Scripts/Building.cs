using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	public bool townhall;
	public float timer;
	public GameObject newUnit;

	void Start () {
		timer = 10f;
	}

	void Update () {
		if (townhall) {
			timer += Time.deltaTime;
			if (timer >= 10) {
				SpawnSoldier();
				timer = 0;
			}
		}
	}

	void SpawnSoldier() {
		GameObject.Instantiate(newUnit);
	}
}

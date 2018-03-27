using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {
	public GameObject	hole;
	public GameObject	club;
	public GameObject	clubPlace;

	void Update () {
		club.transform.position = clubPlace.transform.position;
		club.transform.Translate(new Vector3(-0.25f, 0, 0));
	}

}

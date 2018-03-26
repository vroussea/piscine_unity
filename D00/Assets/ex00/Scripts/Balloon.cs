using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
	public GameObject	baloon;
	private float		scale;
	private float		down;
	private float		up;
	private int			tiredness;
	private float		time;

	void Start () {
		scale = 2f;
		down = 0.06f;
		up = 0.6f;
		tiredness = 0;
		time = 0;
	}

	void Update () {
		time += Time.deltaTime;
		if (Input.GetKeyDown("space") && tiredness < 100) {
			scale += up;
			tiredness += 12;
		}

		scale -= down;

		baloon.transform.localScale = new Vector3(scale, scale, scale);

		if (scale > 4 || scale < 0) {
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
			GameObject.Destroy(baloon);
		}

		if (tiredness > 0)
			tiredness--;
	}
}

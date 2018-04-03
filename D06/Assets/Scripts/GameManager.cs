using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool seen;
	public float discretion;
	public GameObject player;
	public Image fillBarGrey;
	public Image fillBarRed;

	public float timer;

	private float redLimit;

	void Start () {
		redLimit = 75f;
	}
	
	// Update is called once per frame
	void Update () {
		if (discretion > 100)
			discretion = 100;
		timer += Time.deltaTime;
		if (discretion > 0 && timer > 0.05 && !seen) {
			discretion--;
			timer = 0;
		}
		fillBarGrey.fillAmount = discretion / redLimit;
		if (discretion >= redLimit) {
			fillBarRed.fillAmount = (discretion - redLimit) / (100f - redLimit);
		}
	}
}

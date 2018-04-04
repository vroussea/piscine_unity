using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool seen;
	public bool run;
	
	public float discretion;
	public GameObject player;
	public Image fillBarGrey;
	public Image fillBarRed;

	public float timer;

	private float redLimit;

	public AudioClip normalMusic;
	public AudioClip alarmMusic;

	private AudioSource audioSource;

	public bool isAlarm;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		redLimit = 75f;
	}
	
	// Update is called once per frame
	void Update () {
		if (discretion >= 100) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (discretion > 75 && !isAlarm) {
			audioSource.clip = alarmMusic;
        	audioSource.loop = true;
        	audioSource.Play();
			isAlarm = true;
		}
		if (isAlarm == true && discretion < 75) {
			isAlarm = false;
			audioSource.clip = normalMusic;
        	audioSource.loop = true;
        	audioSource.Play();
		}
		if (discretion > 100)
			discretion = 100;
		timer += Time.deltaTime;
		if (discretion > 0 && timer > 0.05 && (!seen && !run)) {
			discretion--;
			timer = 0;
		}
		fillBarGrey.fillAmount = discretion / redLimit;
		if (discretion >= redLimit) {
			fillBarRed.fillAmount = (discretion - redLimit) / (100f - redLimit);
		}
	}
}

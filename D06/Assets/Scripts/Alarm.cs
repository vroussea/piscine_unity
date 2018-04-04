using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

	public GameObject gameManager;
	private AudioSource audioSource;

	public AudioClip alarmClip;

	private bool isAlarmSound;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager>().isAlarm && !isAlarmSound) {
			audioSource.clip = alarmClip;
        	audioSource.loop = true;
        	audioSource.Play();
			isAlarmSound = true;
		}
		if (!gameManager.GetComponent<GameManager>().isAlarm && isAlarmSound) {
			isAlarmSound = false;
			audioSource.Stop();
		}
	}
}

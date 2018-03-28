using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

	public GameObject[] players;
	public int			currentPlayer;

	void Start () {
		players = GameObject.FindGameObjectsWithTag("Character");
		Array.Sort(players, CompareObNames);
		if (SceneManager.GetActiveScene().name == "ex00")
			players[currentPlayer].GetComponent<playerScript_ex00>().setMain(true);
		else
			players[currentPlayer].GetComponent<playerScript_ex01>().setMain(true);
	}
	
	void Update () {
		getPlayer();

		if (Input.GetKey("r")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			players = GameObject.FindGameObjectsWithTag("Character");
		}
		
		Vector3 newCameraPos = players[currentPlayer].transform.position;
		newCameraPos.z = -10;
		transform.position = newCameraPos;
	}

	int CompareObNames( GameObject x, GameObject y )
	{
	  return x.name.CompareTo( y.name );
	}

	void getPlayer() {
		if (Input.GetKey("1")) {
			setPlayer(0);
		}
		else if (Input.GetKey("2")) {
			setPlayer(1);
		}
		else if (Input.GetKey("3")) {
			setPlayer(2);
		}
	}

	void setPlayer(int player) {
		if (SceneManager.GetActiveScene().name == "ex00") {
			players[currentPlayer].GetComponent<playerScript_ex00>().setMain(false);
			currentPlayer = player;
			players[currentPlayer].GetComponent<playerScript_ex00>().setMain(true);
		}
		else {
			players[currentPlayer].GetComponent<playerScript_ex01>().setMain(false);
			currentPlayer = player;
			players[currentPlayer].GetComponent<playerScript_ex01>().setMain(true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject[] players;
	private Vector3[]	startPos = new Vector3[3];
	private int			currentPlayer;

	void Start () {
		players = GameObject.FindGameObjectsWithTag("Character");
		currentPlayer = 0;
		players[currentPlayer].GetComponent<playerScript_ex00>().setMain(true);
		startPos[0] = players[0].transform.position;
		startPos[1] = players[1].transform.position;
		startPos[2] = players[2].transform.position;
	}
	
	void Update () {
		getPlayer();

		if (Input.GetKey("r")) {
			resetScene();
		}
		
		Vector3 newCameraPos = players[currentPlayer].transform.position;
		newCameraPos.z = -10;
		transform.position = newCameraPos;
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
		players[currentPlayer].GetComponent<playerScript_ex00>().setMain(false);
		currentPlayer = player;
		players[currentPlayer].GetComponent<playerScript_ex00>().setMain(true);
	}

	void resetScene() {
		setPlayer(0);

		players[0].transform.position = startPos[0];
		players[1].transform.position = startPos[1];
		players[2].transform.position = startPos[2];
	}
}

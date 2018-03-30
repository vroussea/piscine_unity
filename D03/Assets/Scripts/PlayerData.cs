using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	public GameObject	gameManager;
	public GameObject	lifeText;
	public GameObject	energyText;
	public int			life;
	public int			energy;
	
	void Start () {
		life = gameManager.GetComponent<gameManager>().playerHp;
		energy = gameManager.GetComponent<gameManager>().playerEnergy;
	}
	
	void Update () {
		life = gameManager.GetComponent<gameManager>().playerHp;
		energy = gameManager.GetComponent<gameManager>().playerEnergy;
		lifeText.GetComponent<Text>().text = life.ToString();
		energyText.GetComponent<Text>().text = energy.ToString();
	}
}

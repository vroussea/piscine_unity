using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretData : MonoBehaviour {

	public GameObject gameManager;
	public GameObject reloadText;
	public GameObject damageText;
	public GameObject rangeText;
	public GameObject priceText;
	public GameObject turret;
	
	void Start () {
		reloadText.GetComponent<Text>().text = turret.GetComponent<towerScript>().fireRate.ToString();
		damageText.GetComponent<Text>().text = turret.GetComponent<towerScript>().damage.ToString();
		rangeText.GetComponent<Text>().text = turret.GetComponent<towerScript>().range.ToString();
		priceText.GetComponent<Text>().text = turret.GetComponent<towerScript>().energy.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

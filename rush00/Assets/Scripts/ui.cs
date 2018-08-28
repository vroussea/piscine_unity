using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour {

	public GameObject			Player;

	public playerControlWeapon	player_weapon;
	public Text[]				text;
	// Use this for initialization
	void Start () {
		player_weapon = Player.GetComponent<playerControlWeapon>();
		text = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player_weapon.weapon) {
			text[0].enabled = true;
			if (!player_weapon.weapon.isMelee)
				text[1].enabled = true;
			text[0].text = player_weapon.weapon.name;
			text[1].text = player_weapon.weapon.ammoCount.ToString();
		}
		else {
			text[0].enabled = false;
			text[1].enabled = false;
		}
	}
}

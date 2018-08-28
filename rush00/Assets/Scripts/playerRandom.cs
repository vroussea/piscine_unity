using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRandom : MonoBehaviour {

	public Sprite[]				heads;
	public Sprite[]				bodys;

	private SpriteRenderer[]	_sprites;
	// Use this for initialization
	void Awake () {
		_sprites = GetComponentsInChildren<SpriteRenderer>();
	}

	void Start() {
		_sprites[0].sprite = heads[(int)Random.Range(0, heads.Length)];
		_sprites[1].sprite = bodys[(int)Random.Range(0, bodys.Length)];
	}
}

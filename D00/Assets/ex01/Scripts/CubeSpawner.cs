using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public float		time;
	private int			next;
	public GameObject	cube;
	private GameObject	spawned;

	public float		pos_x;


	public string type;

	void Start () {
		time = 0;
		spawned = null;
		next = nextTime();
	}
	
	void Update () {
		time += Time.deltaTime;

		if (Input.GetKeyDown(type) && spawned != null) {
			score();
			destroyCube();
		}

		if (time > next && spawned == null) {
			next = nextTime();
			time = 0;
			SpawnCube();
		}

		if (spawned && spawned.transform.position.y < -6)
			destroyCube();
	}

	void SpawnCube() {
		Vector3 newPos = new Vector3(pos_x, 4, -1);
		spawned = GameObject.Instantiate(cube, newPos, Quaternion.identity);
	}

	void destroyCube() {
		next = nextTime();
		time = 0;
		Destroy(spawned);
		spawned = null;
	}

	int nextTime() {
		int	min = 1;
		int	max = 5;

		return Random.Range(min, max);
	}

	void score () {
		float posCube = spawned.transform.position.y;
		float posStart = 4.0f;
		float posEnd = 8.0f;

		posCube = posCube >= 0 ? 4 - posCube : 4 + posCube * (-1);

		if (posCube < posEnd) {
			Debug.Log("Precision : " + (posCube / posEnd) * 100);
		}
		else {
			Debug.Log("Precision : " + (200 - ((posCube / posEnd) * 100)));
		}
	}
}

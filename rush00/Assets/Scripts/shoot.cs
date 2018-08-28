using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	private Vector3 dir;
	public float speed;
	public float duration;
	private float timer;
	private Rigidbody2D rigidbody2D;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.AddForce(Vector3.Normalize(dir) * Time.deltaTime * speed);
	}

	 void Update () {
		 timer += Time.deltaTime;
		 if (timer >= duration)
		 	Destroy(gameObject);
	// 	transform.Translate(Vector3.Normalize(dir) * Time.deltaTime * speed);
	 }

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Walls")
            Destroy(gameObject);
    }

	public void setDir(Vector3 _dir) {
		dir = _dir;
	}
}

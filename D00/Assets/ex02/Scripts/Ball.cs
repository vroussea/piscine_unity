using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public GameObject	hole;
	public GameObject	ball;
	public GameObject	club;
	public GameObject	clubPlace;
	public float		speed;
	public float		strength;
	public bool			changeDir;
	public int			score;
	public Vector3		oldpos;

	void Start () {
		speed = 0;
		strength = 0;
		changeDir = false;
		score = -15;
	}
	
	void Update () {
		if (speed + strength == 0) {
			moveClubPlace();
		}

		if (Input.GetKey("space")) {
			if (strength == 0) {
				oldpos = clubPlace.transform.position;			
			}
			moveClubPlaceBack();
			if (speed == 0) {
				checkDir();
			}
			strength += 1.5f;
		}
		else
		{
			if (strength > 0) {
				score += 5;
				Debug.Log("Score: " + score);
				if (score == 5)
					Debug.Log("You lost");
				clubPlace.transform.position = oldpos;
			}
			speed += Mathf.Clamp(strength, 0, 100);
			strength = 0;
		}

		checkWin();

		hitWall();

		
		
		if (speed > 0) {
			moveBall();
		}
		speed = Mathf.Clamp(speed - 1, 0, 100);
	}

	void moveClubPlace() {
		clubPlace.transform.position = ball.transform.position;
	}

	void moveClubPlaceBack() {
		clubPlace.transform.Translate(new Vector3(0, -0.01f, 0));
	}

	void moveBall() {
		if (changeDir == false) {
			ball.transform.Translate(new Vector3(0, speed / 100, 0));
		}
		else {
			ball.transform.Translate(new Vector3(0, -speed / 100, 0));
		}
	}

	void hitWall() {
		if (changeDir == false && ball.transform.position.y + speed / 200 >= 4.7) {
			changeDir = true;
		}
		else if (changeDir == true && ball.transform.position.y - speed / 200 <= -4.7) {
			changeDir = false;
		}
	}

	void checkDir() {
		if (ball.transform.position.y > hole.transform.position.y) {
			changeDir = true;
		}
		else if (ball.transform.position.y < hole.transform.position.y) {
			changeDir = false;
		}
	}

	void checkWin() {
		if (ball.transform.position.y <= 3.1f && ball.transform.position.y >= 2.9 && speed < 14)
			Destroy(ball);
	}
}

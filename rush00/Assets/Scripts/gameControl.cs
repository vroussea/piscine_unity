using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour {
	public GameObject menuDead;
	public GameObject menuWin;
	public playerControl player;

	public GameObject ennemies;

	private AudioSource audioSource;

	public AudioClip youWin;

	private bool win;
	private bool dead;

	public int sceneCount;

	void Start() {
		dead = false;
		audioSource = GetComponent<AudioSource>();
		sceneCount = SceneManager.sceneCountInBuildSettings;
	}

	void Update() {
		if (ennemies && ennemies.transform.childCount <= 0 && !win) {
			audioSource.PlayOneShot(youWin);
			if (!dead)
				menuWin.SetActive(true);
			//StartCoroutine(nextScene());
			win = true;
		}
		if(player && menuDead && player.lost) {
			dead = true;
			menuDead.SetActive(true);
		}
	}

	public void quit() {
		Debug.Log("quit");
		Application.Quit();
	}

	public void changeScene(string scene) {
		Debug.Log("scene load " + scene);
		SceneManager.LoadScene(scene);
	}

	public void reloadSCene() {
		Debug.Log("Reload scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void backToMenu() {
		Debug.Log("Going back to menu");
		SceneManager.LoadScene("menu");
	}

	IEnumerator nextScene() {
		yield return new WaitForSeconds(5);
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex + 1 < sceneCount)
			SceneManager.LoadScene(currentSceneIndex + 1);
		else {
			SceneManager.LoadScene("menu");
		}
	}
}

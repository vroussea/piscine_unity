using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
	void Start() {
		if (name == "Yes" || name == "No") {
			gameObject.SetActive(false);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
    {
			Image image = GetComponent<Image>();
    	Color tempColor = image.color;
			tempColor.a = 255f / 255f;
			image.color = tempColor;
    }

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
     {
         if (name == "Start") {
			Debug.Log("Start");
			SceneManager.LoadScene(1);
		} else if (name == "Exit") {
			Debug.Log("Exit");
		 	Application.Quit();
		} else if (name == "QuitButton") {
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(1).gameObject.SetActive(true);
		}
		else if (name == "No") {
			transform.parent.parent.parent.gameObject.GetComponent<Menu>().isMenuActive = false;
			transform.parent.parent.parent.gameObject.GetComponent<Menu>().changingMenuActiveness = true;
			transform.parent.GetChild(0).gameObject.SetActive(false);
			gameObject.SetActive(false);
		}
		else if (name == "Yes") {
			SceneManager.LoadScene(0);
		}
     }

    public void OnPointerExit(PointerEventData eventData)
    {
			Image image = GetComponent<Image>();
			Color tempColor = image.color;
			tempColor.a = 180f / 255f;
			image.color = tempColor;
    }
}

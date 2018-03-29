using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

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
				 }
				 else {
					 Debug.Log("Exit");
		 				Application.Quit();
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

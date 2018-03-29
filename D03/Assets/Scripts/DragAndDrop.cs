using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
  private Vector3 startPosition;
  private Transform startParent;

  public void OnBeginDrag(PointerEventData eventData)
  {
      itemBeingDragged = gameObject;
      startPosition = transform.position;
      startParent = transform.parent;
  }

    public void OnDrag(PointerEventData eventData)
  {
      transform.position = Input.mousePosition;
  }

    public void OnEndDrag(PointerEventData eventData)
  {
      itemBeingDragged = null;
      if (transform.parent == startParent)
          transform.position = startPosition;
  }
}

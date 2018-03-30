using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

  private Raycast raycast;

  public Vector3 startPosition;
  public Vector3 mousePosition;
  public GameObject turret;

  public void OnBeginDrag (PointerEventData eventData) {
    startPosition = transform.position;
    raycast = GetComponent<Raycast>();
  }

    public void OnDrag(PointerEventData eventData)
  {
    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = -1;
    transform.position = mousePosition;
  }

    public void OnEndDrag(PointerEventData eventData)
  {
      Collider2D collider = raycast.CastRay(mousePosition, Vector2.zero);
      if (collider != null) {
        GameObject tile = collider.gameObject;
        if (tile.tag == "empty") {
          Instantiate(turret, tile.transform.position, Quaternion.identity);
          Destroy(tile);
        }
      }
      transform.position = startPosition;
  }
}

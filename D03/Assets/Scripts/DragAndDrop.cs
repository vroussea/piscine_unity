using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

  private Raycast raycast;
  public GameObject gameManager;

  public Vector3 startPosition;
  public Vector3 mousePosition;
  public GameObject turret;

  public bool canBePurchased;
  private bool inPurchase;
  private int turretPrice;

  private Color startingColor;

  void Start() {
    turretPrice = turret.GetComponent<towerScript>().energy;
    startingColor = GetComponent<Image>().color;
  }

  void Update() {
    if (gameManager.GetComponent<gameManager>().playerEnergy >= turretPrice) {
      canBePurchased = true;
    }
    else
    {
      Color color = GetComponent<Image>().color;
      color = Color.red;
      GetComponent<Image>().color = color;
      canBePurchased = false;
    }
  }

  public void OnBeginDrag (PointerEventData eventData) {
    startPosition = transform.position;
    raycast = GetComponent<Raycast>();
  }

    public void OnDrag(PointerEventData eventData)
  {
    if (canBePurchased) {
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = -1;
      transform.position = mousePosition;
      inPurchase = true;
    }
  }

    public void OnEndDrag(PointerEventData eventData)
  {
    if (canBePurchased && inPurchase) {
      Collider2D collider = raycast.CastRay(mousePosition, Vector2.zero);
      if (collider != null) {
        GameObject tile = collider.gameObject;
        if (tile.tag == "empty") {
          gameManager.GetComponent<gameManager>().playerEnergy -= turretPrice;
          Instantiate(turret, tile.transform.position, Quaternion.identity);
          Destroy(tile);
        }
      }
      transform.position = startPosition;
      inPurchase = false;
    }
  }
}

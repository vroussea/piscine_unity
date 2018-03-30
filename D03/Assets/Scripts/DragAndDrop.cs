using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

  private Raycast raycast;
  public GameObject gameManager;

  public Vector3 startPosition;
  public Vector3 mousePosition;
  public GameObject turret;
  public GameObject turretImagePrefab;
  private GameObject turretImage;

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
      GetComponent<Image>().color = startingColor;
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
    if (canBePurchased) {
      GetComponent<Image>().enabled = false;
      turretImage = Instantiate(turretImagePrefab, transform.position, Quaternion.identity);
    }
  }

    public void OnDrag(PointerEventData eventData)
  {
    if (canBePurchased) {
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.z = -0.1f;
      turretImage.transform.position = mousePosition;
      inPurchase = true;

    }
  }

    public void OnEndDrag(PointerEventData eventData)
  {
    if (canBePurchased && inPurchase) {
      Vector3 screenPoint = Camera.main.WorldToViewportPoint(mousePosition);
      bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
      Collider2D collider = raycast.CastRay(mousePosition, Vector2.zero);
      if (collider != null && onScreen) {
        GameObject tile = collider.gameObject;
        if (tile.tag == "empty") {
          gameManager.GetComponent<gameManager>().playerEnergy -= turretPrice;
          Instantiate(turret, tile.transform.position, Quaternion.identity);
          Destroy(tile);
        }
      }
      Destroy(turretImage);
      GetComponent<Image>().enabled = true;
      inPurchase = false;
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed;
  public float objectHolderOffset;
  private InteractableObject targetObject;
  private ObjectHolder objectHolder;
  private GameManager gameManager;
  private int pickupCount;

  void Start()
  {
    objectHolder = FindObjectOfType<ObjectHolder>();
    gameManager = FindObjectOfType<GameManager>();
  }

  void Update()
  {
    float verticalInput = Input.GetAxis("Vertical");

    float xDirection = Camera.main.transform.forward.x;
    float yDirection = Camera.main.transform.forward.y;
    float zDirection = Camera.main.transform.forward.z;

    Vector3 lookingDirection = new Vector3(xDirection, yDirection, zDirection);

    objectHolder.transform.localPosition = lookingDirection
        * objectHolderOffset;

    transform.Translate(lookingDirection * verticalInput * moveSpeed * Time.deltaTime);

    HandleInteract();
  }

  public void SetTargetObject(InteractableObject interactableObject)
  {
    targetObject = interactableObject;

    Debug.Log("target: " + targetObject);
  }

  public void ClearTargetObject()
  {
    targetObject = null;
    Debug.Log("target: " + targetObject);
  }

  private void HandleInteract()
  {
    if (Input.GetButtonDown("Interact"))
    {
      // The player can't interact with another object if it already holding one
      if (objectHolder.GetHeldObject() != null)
        objectHolder.ClearHeldObject();
      else
      {
        if (targetObject != null)
          targetObject.InteractWith();
      }
    }
  }

  public void PickupItem(PickupItem pickup)
  {
    pickupCount++;
    Destroy(pickup.gameObject);
    gameManager.UpdateScore(pickupCount);
  }
}
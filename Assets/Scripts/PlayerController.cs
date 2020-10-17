using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float objectHolderOffset;
    private IInteractable targetObject;
    private ObjectHolder objectHolder;
    
    void Start()
    {
        objectHolder = FindObjectOfType<ObjectHolder>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        float xDirection = Camera.main.transform.forward.x;
        float zDirection = Camera.main.transform.forward.z;

        Vector3 lookingDirection = new Vector3(xDirection, 0, zDirection);

        objectHolder.transform.localPosition = new Vector3(xDirection, objectHolder.transform.localPosition.y, zDirection) 
            * objectHolderOffset;
        
        transform.Translate(lookingDirection * verticalInput * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Grab"))
        {
            if (objectHolder.GetHeldObject() != null)
                objectHolder.ClearHeldObject();
            else
            {
                if (targetObject is HoldableObject)
                    objectHolder.SetHeldObject((HoldableObject) targetObject);
            }
        }
    }

    public void SetTargetObject(GameObject gameObject)
    {
        IInteractable interactableObject = gameObject.GetComponent<IInteractable>();

        if (interactableObject != null)
            targetObject = interactableObject;

        Debug.Log("target: " + targetObject);
    }

    public void ClearTargetObject()
    {
        targetObject = null;
        Debug.Log("target: " + targetObject);
    }

    public IInteractable GetTargetObject()
    {
        return targetObject;
    }
}

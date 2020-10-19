using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectHolder : MonoBehaviour
{
    private HoldableObject heldObject = null;
    private bool hasCollided;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (heldObject != null)
        {
            heldObject.transform.position = transform.position;
            heldObject.transform.localRotation = transform.rotation;
        }
        */
    }

    public void SetHeldObject(HoldableObject gameObject)
    {
        heldObject = gameObject;

        heldObject.transform.parent = transform;

        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        heldObject.transform.position = transform.position;
        heldObject.transform.localRotation = new Quaternion(heldObject.transform.localRotation.x, 
            transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    public void ClearHeldObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.parent = null;
        heldObject = null;
    }

    public HoldableObject GetHeldObject()
    {
        return heldObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectHolder : MonoBehaviour
{
    private HoldableObject heldObject = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHeldObject(HoldableObject gameObject)
    {
        heldObject = gameObject;
        heldObject.GetComponent<PositionConstraint>().constraintActive = true;
        heldObject.GetComponent<RotationConstraint>().constraintActive = true;
    }

    public void ClearHeldObject()
    {
        heldObject.GetComponent<PositionConstraint>().constraintActive = false;
        heldObject.GetComponent<RotationConstraint>().constraintActive = false;
        heldObject = null;
    }

    public HoldableObject GetHeldObject()
    {
        return heldObject;
    }
}

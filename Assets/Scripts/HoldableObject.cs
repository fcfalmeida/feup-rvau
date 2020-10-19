using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : InteractableObject
{
    private ObjectHolder objectHolder;

    void Start()
    {
        objectHolder = FindObjectOfType<ObjectHolder>();
    }

    public override void InteractWith()
    {
        objectHolder.SetHeldObject(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        /*
        if (objectHolder.GetHeldObject() != null)
            objectHolder.ClearHeldObject();
        */
    }
}

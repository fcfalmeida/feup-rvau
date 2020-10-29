using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectHolder : MonoBehaviour
{
    public float throwVelocity;
    private HoldableObject heldObject = null;
    private bool hasCollided;
    private TrajectoryController trajectoryDisplay;
    private LineRenderer line;

    void Start()
    {
        trajectoryDisplay = GetComponent<TrajectoryController>();
        line = GetComponent<LineRenderer>();
    }

    public void SetHeldObject(HoldableObject gameObject)
    {
        heldObject = gameObject;

        heldObject.transform.parent = transform;

        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        heldObject.transform.position = transform.position;
        heldObject.transform.localRotation = new Quaternion(heldObject.transform.localRotation.x, 
            transform.rotation.y, transform.rotation.z, transform.rotation.w);

        line.enabled = true;
        trajectoryDisplay.enabled = true;

        gameObject.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void ClearHeldObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.parent = null;

        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
        heldObject.GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, transform.right) * forward * throwVelocity);

        heldObject = null;

        trajectoryDisplay.enabled = false;
        line.enabled = false;

        gameObject.gameObject.layer = LayerMask.NameToLayer("Default");

    }

    public HoldableObject GetHeldObject()
    {
        return heldObject;
    }
}

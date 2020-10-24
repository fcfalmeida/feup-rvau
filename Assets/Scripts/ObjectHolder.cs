using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjectHolder : MonoBehaviour
{
    public ThrowCursor cursor;
    private HoldableObject heldObject = null;
    private bool hasCollided;
    private TrajectoryController trajectoryDisplay;
    private LineRenderer line;

    void Start()
    {
        trajectoryDisplay = GetComponent<TrajectoryController>();
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        /*
        if (heldObject != null)
        {
            Vector3 dir = Quaternion.AngleAxis(-45, transform.right) * transform.forward;
            Vector3[] trajectory = Ballistics.GetBallisticPath(transform.position, dir, 5, 0.1f);
            
            line.positionCount = trajectory.Length;
            line.SetPositions(trajectory);
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

        line.enabled = true;
        trajectoryDisplay.enabled = true;
        cursor.gameObject.SetActive(true);

        gameObject.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void ClearHeldObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.parent = null;

        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
        heldObject.GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, transform.right) * forward * 200);

        heldObject = null;

        trajectoryDisplay.enabled = false;
        line.enabled = false;
        cursor.gameObject.SetActive(false);

        gameObject.gameObject.layer = LayerMask.NameToLayer("Default");

    }

    public HoldableObject GetHeldObject()
    {
        return heldObject;
    }
}

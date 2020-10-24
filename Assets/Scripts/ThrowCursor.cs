using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCursor : MonoBehaviour
{
    public LayerMask layer;

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5)) 
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        float xDirection = Camera.main.transform.forward.x;
        float zDirection = Camera.main.transform.forward.z;

        Vector3 lookingDirection = new Vector3(xDirection, 0, zDirection);
        
        transform.Translate(lookingDirection * verticalInput * moveSpeed * Time.deltaTime);
    }
}

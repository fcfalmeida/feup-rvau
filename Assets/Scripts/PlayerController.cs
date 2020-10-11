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
        Vector3 lookingDirection = Camera.main.transform.forward;
        transform.Translate(lookingDirection * verticalInput * moveSpeed * Time.deltaTime);
    }
}

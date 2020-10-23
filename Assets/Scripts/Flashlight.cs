using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn;
    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            isOn = !isOn;
            Debug.Log("Is on: " + isOn);
            light.enabled = isOn;
        }
    }
}

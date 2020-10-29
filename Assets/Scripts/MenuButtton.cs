using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButtton : MonoBehaviour
{
    public UnityEvent onInteract;
    private bool focused;

    void Update() 
    {
        if (focused && Input.GetButtonDown("Interact"))
            onInteract.Invoke();
    }

    public void OnGazeEnter()
    {
        focused = true;
    }

    public void OnGazeExit()
    {
        focused = false;
    }
}

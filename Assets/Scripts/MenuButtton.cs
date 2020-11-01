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
        {
            focused = false;
            onInteract.Invoke();
        }
    }

    public void OnGazeEnter()
    {
        Debug.Log(gameObject + " is focused");
        focused = true;
    }

    public void OnGazeExit()
    {
        focused = false;
        Debug.Log(gameObject + " no longer focused");
    }
}

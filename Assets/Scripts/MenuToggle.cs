using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class OnChangeEvent : UnityEvent<bool> {}

public class MenuToggle : MonoBehaviour
{
    public OnChangeEvent onChange;
    private bool focused;
    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (focused && Input.GetButtonDown("Interact"))
        {
            toggle.isOn = !toggle.isOn;
            onChange.Invoke(toggle.isOn);
        }
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

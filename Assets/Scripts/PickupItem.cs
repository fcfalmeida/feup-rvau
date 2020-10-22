using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : InteractableObject
{
    private PlayerController player;

    void Start() 
    {
        player = FindObjectOfType<PlayerController>();    
    }

    public override void InteractWith()
    {
        player.PickupItem(this);
    }
}

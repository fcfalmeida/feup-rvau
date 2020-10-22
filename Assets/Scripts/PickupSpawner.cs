using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] spawnLocations;

    private List<PickupItem> pickups = new List<PickupItem>();

    void Start()
    {
        // Search for pickups in the PickupStash which are then relocated
        GameObject pickupStash = GameObject.FindGameObjectWithTag("PickupStash");

        foreach (Transform pickup in pickupStash.transform)
            pickups.Add(pickup.GetComponent<PickupItem>());

        // Spawn the specified number of pickups in a set of predefined locations, choosing
        // numberOfPickups locations at random
        List<int> list = new List<int>();
 
        for (int i = 0; i < pickups.Count; i++)
        {
            int rand = Random.Range(0, spawnLocations.Length);

            while (list.Contains(rand))
                rand = Random.Range(0, spawnLocations.Length);

            list.Add(rand);

            pickups[i].transform.parent = spawnLocations[rand].transform;
            pickups[i].transform.position = spawnLocations[rand].transform.position;
            pickups[i].transform.rotation = spawnLocations[rand].transform.rotation;
        }

        // PickupStash is no longer needed
        Destroy(pickupStash);
    }
}

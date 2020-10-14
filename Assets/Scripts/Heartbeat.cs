using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
  private AudioSource heartbeat;

  // Start is called before the first frame update
  void Start()
  {
    heartbeat = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown("u"))
    {
      heartbeat.pitch += 0.1f;
    }
    else
    {
      if (Input.GetKeyDown("d"))
      {
        heartbeat.pitch -= 0.1f;
      }
    }
  }
}

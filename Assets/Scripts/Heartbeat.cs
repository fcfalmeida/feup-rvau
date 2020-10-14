using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
  private AudioSource heartbeat;

  private GameObject player;
  private GameObject slenderman;
  private static float MIN_HEARBEAT_PITCH = 0.6f;
  private static float MAX_HEARTBEAT_PITCH = 1.3f;
  private static float MIN_DISTANCE = 10f;

  // Start is called before the first frame update
  void Start()
  {
    heartbeat = GetComponent<AudioSource>();
    player = GameObject.Find("Player");
    slenderman = GameObject.Find("Test");
  }

  // Update is called once per frame
  void Update()
  {
    float z = player.transform.position.z - slenderman.transform.position.z;
    float y = player.transform.position.y - slenderman.transform.position.y;
    float x = player.transform.position.x - slenderman.transform.position.x;
    float distance = Mathf.Pow((Mathf.Pow(z, 2) + Mathf.Pow(y, 2) + Mathf.Pow(x, 2)), 0.5f);
    /*if (distance < 5.0f)
    {
      heartbeat.pitch = 1.2f;
      return;
    }
    if (distance < 7.0f)
    {
      heartbeat.pitch = 1.1f;
      return;
    }
    if (distance < 10.0f)
    {
      heartbeat.pitch = 1.0f;
      return;
    }
    if (distance < 12.0f)
    {
      heartbeat.pitch = 0.9f;
      return;
    }
    if (distance < 14.0f)
    {
      heartbeat.pitch = 0.9f;
      return;
    }
    if (distance < 16.0f)
    {
      heartbeat.pitch = 0.8f;
      return;
    }
    if (distance < 20.0f)
    {
      heartbeat.pitch = 0.7f;
      return;
    }
    else
    {
      heartbeat.pitch = 0.6f;
      return;
    }*/
    float heartbeatPitch = MIN_DISTANCE / distance;
    heartbeatPitch = heartbeatPitch > MAX_HEARTBEAT_PITCH ? MAX_HEARTBEAT_PITCH : heartbeatPitch;
    heartbeat.pitch = heartbeatPitch < MIN_HEARBEAT_PITCH ? MIN_HEARBEAT_PITCH : heartbeatPitch;
  }
}

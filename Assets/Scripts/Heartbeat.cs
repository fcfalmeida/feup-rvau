using UnityEngine;

public class Heartbeat : MonoBehaviour
{
  public AudioSource heartbeat;

  public GameObject player;
  public GameObject slenderman;
  public float MIN_HEARBEAT_PITCH;
  public float MAX_HEARTBEAT_PITCH;
  public float MIN_DISTANCE;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    float distance = Vector3.Distance(player.transform.position, slenderman.transform.position);
    float heartbeatPitch = MIN_DISTANCE / distance;
    heartbeatPitch = heartbeatPitch > MAX_HEARTBEAT_PITCH ? MAX_HEARTBEAT_PITCH : heartbeatPitch;
    heartbeat.pitch = heartbeatPitch < MIN_HEARBEAT_PITCH ? MIN_HEARBEAT_PITCH : heartbeatPitch;
  }
}

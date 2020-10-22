using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
  public Transform CameraTransform;
  [SerializeField] Vector3 offSet;
  // Start is called before the first frame update
  void Start()
  {
    CameraTransform.localPosition = offSet;
  }

  // Update is called once per frame
  void Update()
  {
    CameraTransform.localPosition = offSet;
  }
}

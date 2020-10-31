using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
  public Transform CameraTransform;
  public Vector3 offset;
  [SerializeField] private Vector3 _offSet;
  // Start is called before the first frame update
  void Start()
  {
    CameraTransform.localPosition = _offSet;
  }

  // Update is called once per frame
  void Update()
  {
    _offSet = offset;
    CameraTransform.localPosition = _offSet;
  }
}

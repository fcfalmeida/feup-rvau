using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    gameObject.GetComponent<LockCamera>().enabled = false;
    gameObject.GetComponent<LockCamera>().enabled = true;
  }

  // Update is called once per frame
  void Update()
  {

  }
}

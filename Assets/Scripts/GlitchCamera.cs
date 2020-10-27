using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchCamera : MonoBehaviour
{
    Animator animator;
    GameObject slender;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        slender = GameObject.Find("Slenderman");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(slender.transform.position, transform.position);
        float angle = Vector3.Angle(transform.forward, slender.transform.position - transform.position);

        if (angle < 40 && distance < 8)
        {
            animator.SetBool("bzz", true);
        }
        else
        {
            animator.SetBool("bzz", false);
        }
    }
}

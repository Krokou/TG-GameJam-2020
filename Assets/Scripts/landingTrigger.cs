using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingTrigger : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("SquashBool", true);
    }
}

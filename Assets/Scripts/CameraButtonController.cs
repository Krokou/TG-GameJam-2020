using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            WinCircleController.cameraButtonPushed_B = true;
            //Debug.Log("Camera button hit");
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    Camera mainCamera;
    bool carrying = false;
    GameObject carriedObject;
    public float distance = 2;
    public float smooth = 6;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }

    /* void rotateObject()
    {
        
    }
    */

    void carry(GameObject obj)
    {
        obj.GetComponentInParent<Rigidbody>().velocity = ((mainCamera.transform.position + mainCamera.transform.forward * distance) - obj.transform.position) * smooth;
            
            //Vector3.Lerp(obj.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }
    void pickup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                PickUpable p = hit.collider.GetComponent<PickUpable>();
                if(p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
    void checkDrop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        carriedObject.GetComponentInParent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }

    
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighlightObject : MonoBehaviour
{
    //Changes the color of the material on the object the mouse hovers over if
    // the object has this script on it and a collider. Collider can also be trigger.
    private Color originalColor_C;
    private Renderer curRenderer_R;


    public GameObject rotationIcon_E;
    public GameObject rotationIcon_R;



    private void Start()
    {
        //Grab the current renderer on the object at start.
        curRenderer_R = GetComponent<Renderer>();

        //Debug.Log("curRenderer_R: " + curRenderer_R.gameObject.name);
    }

    private void OnMouseEnter()
    {
        //Debug.Log("mouse over");
        //Store original color/texture to use when mouse stops hovering over the object.
        originalColor_C = curRenderer_R.material.color;
        //Change material color to what ever looks best.
        curRenderer_R.material.color = Color.yellow;

        rotationIcon_E.gameObject.SetActive(true);
        rotationIcon_R.gameObject.SetActive(true);
       
    }

    private void OnMouseExit()
    {
        //Change color of matierial back to the original color/texture.
        curRenderer_R.material.color = originalColor_C;
        rotationIcon_E.gameObject.SetActive(false);
        rotationIcon_R.gameObject.SetActive(false);
    }
}

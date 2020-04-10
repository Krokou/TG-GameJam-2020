using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightlightFromCamera : MonoBehaviour
{
    public Material highlightMaterial;
    Material originalMaterial;
    GameObject lastHighlightedObject;

    public GameObject rotationIcon_E;
    public GameObject rotationIcon_R;

    void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlightedObject = gameObject;
        }

    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }

    void HighlightObjectInCenterOfCam()
    {
        float rayDistance = 1000.0f;
        // Ray from the center of the viewport.
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rayHit;
        // Check if we hit something.
        if (Physics.Raycast(ray, out rayHit, rayDistance))
        {
            // Get the object that was hit.
            GameObject hitObject = rayHit.collider.gameObject;
            if(hitObject.GetComponent<MeshRenderer>() != null && hitObject.GetComponent<PickUpable>() != null)
            {
                HighlightObject(hitObject);
                rotationIcon_E.gameObject.SetActive(true);
                rotationIcon_R.gameObject.SetActive(true);
            }
            else
            {
                rotationIcon_E.gameObject.SetActive(false);
                rotationIcon_R.gameObject.SetActive(false);
                return;
            }

            
        }
        else
        {
            ClearHighlighted();
        }
    }

    void Update()
    {
        HighlightObjectInCenterOfCam();
    }
}

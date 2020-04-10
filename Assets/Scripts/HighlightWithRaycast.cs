using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightWithRaycast : MonoBehaviour
{

    public float distanceToSee = 100f;
    public string ObjectName;
    private Color highlightColor;
    private Color originalColor;
    Material originalMaterial, tempMaterial;
    Renderer rend = null;
    Renderer currRend;

    // Start is called before the first frame update
    void Start()
    {
        highlightColor = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        


        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee))
        {
            Debug.Log("hitInfo: " + hitInfo.transform.name);
            
            if (hitInfo.collider.gameObject.GetComponent<Renderer>() != null)
            {
                originalColor = currRend.material.color;
                currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();
                currRend.material.color = Color.yellow;
                
            }

            if (currRend && currRend != rend)
            {

            }

                /*
                if (currRend == rend)
                {
                    Debug.Log("current is same as previous");
                    return;
                }


                if (currRend && currRend != rend)
                {
                    if (rend)
                    {
                        Debug.Log("rend exists and isn't same as previous");
                        rend.material.color = originalColor;
                    }

                }

                if (currRend)
                {
                    rend = currRend;
                }                
                else
                {
                    Debug.Log("current rend doesn't exist");
                    return;
                }


                //originalMaterial = rend.sharedMaterial;

                //tempMaterial = new Material(originalMaterial);
                //rend.material = tempMaterial;
                rend.material.color = highlightColor;
                */
            }
        /*
        else
        {
            if (rend)
            {
                Debug.Log("back to original color");
                rend.material.color = originalColor;
                rend = null;
            }
        }
        */


    }
}

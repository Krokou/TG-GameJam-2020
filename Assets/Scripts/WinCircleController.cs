using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCircleController : MonoBehaviour
{
    private GameObject[] kittensArray_A;
    private int allKittensCount_Int;
    private bool countKitten_B = true;

    //Count for kittens in circle area.
    private int count_Int = 0;
    public static bool cameraButtonPushed_B = false;

    // Start is called before the first frame update
    void Start()
    {
        CountAllKittens();
    }

    // Update is called once per frame
    void Update()
    {
        WinConditionChecker();
    }

    private void CountAllKittens()
    {
        kittensArray_A = GameObject.FindGameObjectsWithTag("kitten_Tag");
        allKittensCount_Int = kittensArray_A.Length;
        //Debug.Log("allKittensCount_Int: " + allKittensCount_Int);
    }

    //Check for kittens and add to the count.
    private IEnumerator OnTriggerEnter(Collider other)
    {
        
        if(other.transform.parent != null && other.transform.parent.tag == "kitten_Tag")
        {
            
            count_Int += 1;
            Debug.Log("kitten here, count: " + count_Int);
           
        }
        yield return null;
    }

    //Check for kittens and subtract from the count.
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.tag == "kitten_Tag")
        {
            count_Int -= 1;
            Debug.Log("kitten here, count: " + count_Int);
        }
    }

    //If all kittens inside circle and camera button pushed then win.
    private void WinConditionChecker()
    {
        if(count_Int == allKittensCount_Int*2 && (cameraButtonPushed_B == true || Input.GetKey(KeyCode.T)))
        {

            Debug.Log("Win");
        }            
    }
}

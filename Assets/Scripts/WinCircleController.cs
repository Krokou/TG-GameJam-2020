using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCircleController : MonoBehaviour
{
    private GameObject[] kittensArray_A;
    private int allKittensCount_Int;
    private bool countKitten_B = true;

    public GameObject victoryImage_GO;

    //Count for kittens in circle area.
    private int count_Int = 0;
    public static bool cameraButtonPushed_B = false;
    private bool victory_B = false;
    private bool showVictoryImage_B = true;

    // Start is called before the first frame update
    void Start()
    {
        CountAllKittens();
    }

    // Update is called once per frame
    void Update()
    {
        WinConditionChecker();
        HideVictoryImageChecker();
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
        if(count_Int == allKittensCount_Int*2 && Input.GetKey(KeyCode.T))
        {
            //Debug.Log("Win");
            victory_B = true;
            ShowVictoryImage();
        }            
    }

    private void ShowVictoryImage()
    {
        if(victory_B == true && showVictoryImage_B == true)
        {
            victoryImage_GO.SetActive(true);
        }        
    }

    private void HideVictoryImageChecker()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            showVictoryImage_B = false;
            victoryImage_GO.SetActive(false);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player_Pref;
    private GameObject player_GO;
    public Transform spawnPos_TF;
    private bool frozen_B = true;

    // Start is called before the first frame update
    void Awake()
    {
        //player_GO = Instantiate(player_Pref, spawnPos_TF.position, spawnPos_TF.rotation);
        StartCoroutine(UnfreezeDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(frozen_B == true)
        {
            player_Pref.transform.position = spawnPos_TF.position;
        }
    }

    private IEnumerator UnfreezeDelay()
    {
        yield return new WaitForSeconds(0.1f);
        frozen_B = false;
    }
}

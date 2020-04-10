using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player_Pref;
    private GameObject player_GO;
    public Transform spawnPos_TF;

    // Start is called before the first frame update
    void Awake()
    {
        player_GO = Instantiate(player_Pref, spawnPos_TF.position, spawnPos_TF.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

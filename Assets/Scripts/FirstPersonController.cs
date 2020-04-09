using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed_F;

    private float horizontal_F, vertical_F;
    private Vector3 playerMovement_V3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementUpdate();
        
    }

    //Movement for the player.
    private void PlayerMovementUpdate()
    {
        horizontal_F = Input.GetAxis("Horizontal");
        vertical_F = Input.GetAxis("Vertical");

        playerMovement_V3 = new Vector3(horizontal_F, 0, vertical_F) * speed_F * Time.deltaTime;
        transform.Translate(playerMovement_V3, Space.Self);
    }
}

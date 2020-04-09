using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed_F = 1f;
    public Transform target_TF, player_TF;

    private float mouseX_F, mouseY_F;

    // Start is called before the first frame update
    void Start()
    {
        LockCursorAndMakeInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        CamControlUpdate();
    }

    //Controls the camera on the player.
    private void CamControlUpdate()
    {
        mouseX_F += Input.GetAxis("Mouse X") * rotationSpeed_F;
        mouseY_F -= Input.GetAxis("Mouse Y") * rotationSpeed_F;
        //To prevent the camera from flipping over or under when looking up or down.
        mouseY_F = Mathf.Clamp(mouseY_F, -35, 60);

        transform.localRotation = Quaternion.Euler(mouseY_F, 0, 0);
        player_TF.rotation = Quaternion.Euler(0, mouseX_F, 0);
    }

    //Lock the cursor and make it invisible.
    private void LockCursorAndMakeInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

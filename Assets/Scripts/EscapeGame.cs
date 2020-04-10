using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeGame : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject EscapeButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeButton.gameObject.SetActive(true);
            PlayerCamera.GetComponent<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void ContinueGame()
    {
        EscapeButton.gameObject.SetActive(false);
        PlayerCamera.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void LeaveGame()
    {
        Application.LoadLevel(0);
    }
}

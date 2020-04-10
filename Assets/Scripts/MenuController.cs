using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //fetches the setting_panel
    public GameObject settingPanel;

    //Width and height for resolution scaling
    public int width;
    public int height;

    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }

    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }

    public void SetRes()
    {
        Screen.SetResolution(width, height, true);
    }

    //Button functions
    public void startGame()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }

    public void creditsScreen()
    {
        Application.LoadLevel(2);
    }

    public void settingsMenu()
    {
        settingPanel.gameObject.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void settingsBack()
    {
        settingPanel.gameObject.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

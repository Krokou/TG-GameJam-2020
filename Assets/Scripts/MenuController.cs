using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject settingPanel;

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

    public void startGame()
    {
        Application.LoadLevel(1);
    }

    public void settingsMenu()
    {
        settingPanel.gameObject.SetActive(true);
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

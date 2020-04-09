using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class KittenCamera : MonoBehaviour
{
    public RenderTexture kittenPhoto_RTex;
    public Camera kittenCamera_Cam;

    public GameObject savedKittenPhoto_GO;
    private Texture2D savedKittenPhoto_Tex2D;

    private RenderTexture curRenderTexture;
    private Texture2D cameraImage_Tex2D;
    private int imageCount_Int = 1;


    private void Start()
    {
        //Create folder for saved images.
        Directory.CreateDirectory("SavedKittenImages");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.T))
        {
            //Save the snapshot from the camera.
            StartCoroutine(SaveCameraView());
        }
    }

    private IEnumerator SaveCameraView()
    {
        yield return new WaitForEndOfFrame();        

        //Grab the cameras render texture.
        curRenderTexture = RenderTexture.active;
        RenderTexture.active = kittenCamera_Cam.targetTexture;

        //Render the texture.
        kittenCamera_Cam.Render();

        //Set the camera's texture as our Texture 2D texture using the camera texture's width and height.
        cameraImage_Tex2D = new Texture2D(kittenCamera_Cam.targetTexture.width, kittenCamera_Cam.targetTexture.height, TextureFormat.RGB24, false);
        cameraImage_Tex2D.ReadPixels(new Rect(0, 0, kittenCamera_Cam.targetTexture.width, kittenCamera_Cam.targetTexture.height), 0, 0);
        cameraImage_Tex2D.Apply();
        RenderTexture.active = curRenderTexture;

        //Store cameraImage texture onto a separate Texture2D and then add to plane in game.
        savedKittenPhoto_Tex2D = cameraImage_Tex2D;
        savedKittenPhoto_GO.GetComponent<Renderer>().material.mainTexture = savedKittenPhoto_Tex2D;

        //Store the texture into a .PNG file.
        byte[] bytes = cameraImage_Tex2D.EncodeToPNG();

        //Save the encoded image as a file.
        File.WriteAllBytes(Application.dataPath + "/../SavedKittenImages/SavedKittenPhoto" + imageCount_Int + ".png", bytes);
        imageCount_Int += 1;
        //Debug.Log("imageCount_Int: " + imageCount_Int);
    }
}

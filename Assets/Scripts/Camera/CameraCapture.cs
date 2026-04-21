using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    public Camera cam;
    
    private RenderTexture rt;
    
    public int width = 512, height = 512;
    
    
    void Start()
    {
        cam.depth = -100;
        
        rt = new RenderTexture(width, height, 24);
        cam.targetTexture = rt;
    }
    

    public void TakePhoto()
    {
        cam.enabled = true;
        RenderTexture.active = rt;
        Texture2D photo = new Texture2D(width, height);
        photo.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        photo.Apply();
        
        RenderTexture.active = null;
        
        InterfaceScreenDrive.instance.screenDrive.texture = photo;
        //cam.enabled = false;
    }
}

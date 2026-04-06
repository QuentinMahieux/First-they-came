using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    public Camera cam;
    
    public RawImage displayImage;
    
    private RenderTexture rt;
    
    public int width = 512, height = 512;

    void Start()
    {
        cam.depth = -100;
        
        rt = new RenderTexture(width, height, 24);
        cam.targetTexture = rt;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakePhoto();
        }
    }

    void TakePhoto()
    {
        RenderTexture.active = rt;
        Texture2D photo = new Texture2D(width, height);
        photo.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        photo.Apply();
        
        RenderTexture.active = null;
        
        displayImage.texture = photo;
    }
}

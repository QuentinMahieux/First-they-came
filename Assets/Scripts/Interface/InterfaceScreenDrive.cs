using UnityEngine;
using UnityEngine.UI;

public class InterfaceScreenDrive : MonoBehaviour
{
    public static  InterfaceScreenDrive instance;

    public RawImage screenDrive;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[InterfaceScreenDrive] More than one Interface ScreenDrive found!");
            Destroy(gameObject);
        }
    }
}

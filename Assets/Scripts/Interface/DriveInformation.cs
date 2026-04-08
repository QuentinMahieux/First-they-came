using TMPro;
using UnityEngine;

public class DriveInformation : MonoBehaviour
{
    public static DriveInformation instance;

    public TMP_Text plaqueText;
    public TMP_Text speedText;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeText(DriverData driverData)
    {
        Debug.unityLogger.Log("ChangeText");
        plaqueText.text = driverData.plaque;
        speedText.text = driverData.speed + " km/h";
    }
}

using System;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public Rigidbody rb;
    private DriverData driveData;
    public CameraCapture cameraCapture;
    

    void FixedUpdate()
    {
        if (!GameManager.instance.isScanning)
        {
            Vector3 movement = transform.forward * ((driveData.speed/GameManager.instance.settings.divisionSpeedCar) * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + movement);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void InstanceDriver(DriverData data)
    {
        driveData = data;
    }
    
    public void AddDriver()
    {
        cameraCapture.TakePhoto();
        
        GameManager.instance.RadarToVerication(driveData);
        
    }
}

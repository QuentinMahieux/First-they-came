using UnityEngine;

public class Drive : MonoBehaviour
{
    public Rigidbody rb;
    private DriverData driveData;
    
    void FixedUpdate()
    {
        if (!GameManager.instance.isScanning)
        {
            Vector3 movement = transform.forward * ((driveData.speed/11) * Time.fixedDeltaTime);
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
        GameManager.instance.ScanDrive(driveData);
    }
}

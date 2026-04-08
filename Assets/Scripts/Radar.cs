using System;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drive"))
        {
            Drive drive = other.GetComponent<Drive>();
            drive.AddDriver();
        }
    }
    
    
}

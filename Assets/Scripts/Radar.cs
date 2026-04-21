using System;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Camera mainCamera;


    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.violetRed);

        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Drive"))
                {
                    hit.collider.GetComponent<Drive>().AddDriver();
                }
            }
        }
    }
    
}

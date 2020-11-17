using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    // Virtual Camera
    public Cinemachine.CinemachineVirtualCamera CM_Camera;

    public Cinemachine.CinemachineVirtualCamera CM_baseCam;

    public GameObject PlayerObj;

    // When player enters trigger
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
       {
            // set all cameras to zero
            FindObjectOfType<CamManager>().SetAllCamerasToZero();

            // Set referenced camera to high priority
            CM_Camera.Priority = 5;

            // Set New Follow Object to Player Transform
            if(PlayerObj)
            {
                CM_Camera.m_Follow = PlayerObj.transform;
            }

            // set camera to current in camera manager
            FindObjectOfType<CamManager>().currentCam = CM_Camera;
       }
    }

    private void OnTriggerExit(Collider other)
    {
        CM_Camera.Priority = 0;

        CM_baseCam.Priority = 1;
    }
}

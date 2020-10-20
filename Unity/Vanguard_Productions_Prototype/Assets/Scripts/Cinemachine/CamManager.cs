using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    // Current Camera being displayed
    public Cinemachine.CinemachineVirtualCamera [] CM_VirtualCurrent;

    public Cinemachine.CinemachineVirtualCamera currentCam;

    public Cinemachine.CinemachineVirtualCamera CM_BaseCam;

    private void Update()
    {
        // Handles player looking up
        if (Input.GetKey(KeyCode.W))
        {
            // Set Look up Camera priority to HIGH
            CM_BaseCam.Priority = 1;
        }
        else
        {
            // Set Look up Camera priority to LOW
            CM_BaseCam.Priority = 1;
        }
    }

    public void SetAllCamerasToZero()
    {
        // Set all cameras with priority zero
        // specifically not include 'look around' cameras
        foreach(Cinemachine.CinemachineVirtualCamera cam in CM_VirtualCurrent)
        {
            cam.Priority = 0;
        }
    }
}

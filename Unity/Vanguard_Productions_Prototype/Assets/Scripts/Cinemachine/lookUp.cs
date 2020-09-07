using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookUp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY, distanceUp, speedOfLook * Time.deltaTime);

            // Set priority to lower number
            GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 3;
        }
        else
        {
            // keep the priority high
            GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 5;
        }
    }

}

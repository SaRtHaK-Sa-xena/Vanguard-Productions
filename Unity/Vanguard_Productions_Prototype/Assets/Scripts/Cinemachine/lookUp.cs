using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookUp : MonoBehaviour
{
    public float speedOfLook = 1;
    public float distanceUp = 1.3f;

    float first = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY, distanceUp, speedOfLook * Time.deltaTime);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("Player Move Camera Dwn");
            GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY, first, speedOfLook * Time.deltaTime);
        }

        // Look up on 
        //LookUp();
    }

    void LookUp()
    {
        //if(Input.GetKey(KeyCode.W))
        //{
            //float first = 0.5f;
            //GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY, distanceUp, speedOfLook * Time.deltaTime);
        //}
        //else
        //{
           //GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = 0.5f;
           //float first = 1.3f;
           //GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(distanceUp, 0.5f, speedOfLook * Time.deltaTime);
        //}
    }
}

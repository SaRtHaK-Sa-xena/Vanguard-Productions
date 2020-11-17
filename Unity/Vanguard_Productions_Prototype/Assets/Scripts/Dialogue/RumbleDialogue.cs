using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RumbleDialogue : MonoBehaviour
{
    public bool startDialogue = false;

    public float timerMax = 100f;
    public float currentTime = 0f;

    public GameObject playerObj;

    public float shakeTimerTotal;
    public float shakeTimer;

    public CinemachineVirtualCamera cm_shakeCam;

    public GameObject wardenRoof;

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CM_perlin = cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        CM_perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
        CM_perlin.m_FrequencyGain = 0.1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5f;
            //cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0.1f;
            ShakeCamera(5f, 1f);
        }

        if(FindObjectOfType<PauseMenu>().GamePaused == false)
        {
            if (shakeTimer > 0)
            {
                // stop player movement
                playerObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                playerObj.GetComponent<PlayerControl>().allowMovement = false;

                shakeTimer -= Time.deltaTime;

                if (shakeTimer < 0f)
                {
                    CinemachineBasicMultiChannelPerlin CM_perlin = cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    CM_perlin.m_AmplitudeGain = 0f;
                    CM_perlin.m_FrequencyGain = 0f;

                    startDialogue = true;
                    //currentTime = shakeTimer;
                }
            }
        }
        

        if(startDialogue)
        {
            //currentTime -= Time.deltaTime;

            //if(currentTime < 0)
            //{
                // start dialogue
                spawnDialogue();

                // allow player movement
                playerObj.GetComponent<PlayerControl>().allowMovement = true;

                startDialogue = false;

                wardenRoof.SetActive(false);
            //}
        }
    }


    void spawnDialogue()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}

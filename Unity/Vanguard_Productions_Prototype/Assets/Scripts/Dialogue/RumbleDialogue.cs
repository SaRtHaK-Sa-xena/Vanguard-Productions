using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RumbleDialogue : MonoBehaviour
{
    public bool startTimer;

    public float timerMax = 100f;
    public float currentTime = 0f;

    public GameObject playerObj;

    float shakeTimerTotal;
    float shakeTimer;

    public CinemachineVirtualCamera cm_shakeCam;

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CM_perlin = cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        CM_perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(FindObjectOfType<PauseMenu>().GamePaused == false)
        {
            if (shakeTimer > 0)
            {
                // stop player movement
                playerObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                playerObj.GetComponent<PlayerControl>().allowMovement = false;

                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin CM_perlin = cm_shakeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    CM_perlin.m_AmplitudeGain = 0f;

                    // start dialogue
                    spawnDialogue();

                    // allow player movement
                    playerObj.GetComponent<PlayerControl>().allowMovement = true;
                }
            }
        }
        

    }


    void spawnDialogue()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}

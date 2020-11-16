using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleDialogue : MonoBehaviour
{
    public bool startTimer;

    public float timerMax = 50f;
    public float currentTime = 0f;


    private void Update()
    {
        if(startTimer)
        {
            currentTime++;
            if(currentTime >= timerMax)
            {
                spawnDialogue();
                startTimer = false;
            }
        }
    }

    void spawnDialogue()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}

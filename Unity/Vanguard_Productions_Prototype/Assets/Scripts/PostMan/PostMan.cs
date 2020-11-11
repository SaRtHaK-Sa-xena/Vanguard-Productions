﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMan : MonoBehaviour
{
    // get reference of objectivesManager.
    public Objectives objectivesManager;

    // set in dialogue of postman
    // when the dialogue finished
    public bool finishedTalk;

    private void Awake()
    {
        objectivesManager = FindObjectOfType<Objectives>();
    }

    // on enter
    private void OnTriggerEnter(Collider other)
    {
        // if player
        if (other.CompareTag("Player"))
        {
            // spawn the final memory.
            objectivesManager.FoundPostMan();
        }
    }

    public void EnableTriggerBox()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}

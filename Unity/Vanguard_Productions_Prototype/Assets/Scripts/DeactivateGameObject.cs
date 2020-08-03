﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float timer = 5f;

    public CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        col = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CapsuleCollider>();
        ParticleSystem particle = GetComponentInChildren<ParticleSystem>();

        particle.trigger.SetCollider(0, col);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy [T]");
        }
    }

    private void OnParticleTrigger()
    {
       
    }
}

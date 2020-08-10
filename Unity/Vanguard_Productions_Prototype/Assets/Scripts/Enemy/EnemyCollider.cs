using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    //private CapsuleCollider CapCol;

    // Start is called before the first frame update
    void Start()
    {
        //CapCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If Particle
        if (other.CompareTag("Particle"))
        {
            Debug.Log("Particle Collided");
        }
        Debug.Log("Particle On Enemy");
    }
}

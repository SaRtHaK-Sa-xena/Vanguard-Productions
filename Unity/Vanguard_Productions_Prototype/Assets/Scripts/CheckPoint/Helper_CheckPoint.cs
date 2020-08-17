using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// On Trigger box
/// Activates teleport
/// </summary>
public class Helper_CheckPoint : MonoBehaviour
{
    // on trigger
    private void OnTriggerEnter(Collider other)
    {
        // if player 
        if(other.CompareTag("Player"))
        {
            // if Spawn Point
            if (gameObject.CompareTag("SpawnPoint"))
            {
                // set new spawn position
                FindObjectOfType<CheckPoint>().spawnPosition = transform;
            }


            // if Death Point
            if (gameObject.CompareTag("DeathPoint"))
            {
                // set condition to true
                FindObjectOfType<CheckPoint>().teleport = true;

                // Start teleport
                FindObjectOfType<CheckPoint>().teleportPlayer();
            }
        }
    }
}

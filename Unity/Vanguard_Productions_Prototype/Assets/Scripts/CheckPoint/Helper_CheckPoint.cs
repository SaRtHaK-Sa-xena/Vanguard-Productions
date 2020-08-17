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
        // if Spawn Point
        if(gameObject.CompareTag("SpawnPoint"))
        {
            // set spawn position
            FindObjectOfType<CheckPoint>().spawnPosition = transform;
        }


        if(gameObject.CompareTag("DeathPoint"))
        {
            // set condition to true
            FindObjectOfType<CheckPoint>().teleport = true;
        }

        // if Death Point
    }
}

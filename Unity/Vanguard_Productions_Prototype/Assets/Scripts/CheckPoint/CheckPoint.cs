using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns Player back to certain checkpoints
/// </summary>

public class CheckPoint : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject Player;

    public bool teleport;


    /// <summary>
    /// Teleport back
    /// </summary>
    public void teleportPlayer()
    {
        Player.transform.position = spawnPosition.position;
        Player.GetComponent<HealthScript>().health = 100;
    }

    public void checkTeleportCondition()
    {
        //if()
    }
}

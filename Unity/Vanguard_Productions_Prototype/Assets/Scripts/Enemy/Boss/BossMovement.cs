using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject bossTriggerScript;

    public bool leftSide;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if(leftSide)
            {
                bossTriggerScript.GetComponent<BossTriggerBox>().waypointIndex = 1;
            }
            else
            {
                bossTriggerScript.GetComponent<BossTriggerBox>().waypointIndex = 0;
            }
        }
    }
}

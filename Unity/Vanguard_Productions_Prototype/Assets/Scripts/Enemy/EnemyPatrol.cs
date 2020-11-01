using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy.GetComponent<EnemyMovement>().patrol = false;
            Enemy.GetComponent<EnemyMovement>().followPlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy.GetComponent<EnemyMovement>().patrol = false; 
            Enemy.GetComponent<EnemyMovement>().followPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy.GetComponent<EnemyMovement>().patrol = true;
            Enemy.GetComponent<EnemyMovement>().followPlayer = false;
            Debug.Log("Player Left!");

        }
    }

}

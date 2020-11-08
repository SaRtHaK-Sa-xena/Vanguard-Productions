using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(Enemy.gameObject.name != "CrabBoy")
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().patrol = false;
                Enemy.GetComponent<EnemyMovement>().followPlayer = true;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().jumpAttack();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Enemy.gameObject.name != "CrabBoy")
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().patrol = false;
                Enemy.GetComponent<EnemyMovement>().followPlayer = true;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().jumpAttack();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Enemy.gameObject.name != "CrabBoy")
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().patrol = true;
                Enemy.GetComponent<EnemyMovement>().followPlayer = false;
                Debug.Log("Player Left!");
            }
        }
        else
        {
            if(other.CompareTag("Player"))
            {

            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField] bool crab;

    private void OnTriggerEnter(Collider other)
    {
        if(crab)
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<CrabAI>().patrol = false;
                Enemy.GetComponent<CrabAI>().attackPlayer = true;
                Enemy.GetComponent<CrabAI>().enemyAnim.anim.SetBool("isGround", true);
            }
        }

        else
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().patrol = false;
                Enemy.GetComponent<EnemyMovement>().followPlayer = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (crab)
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<CrabAI>().patrol = false;
                Enemy.GetComponent<CrabAI>().attackPlayer = true;
            }
        }

        else
        {
            if (other.CompareTag("Player"))
            {
                Enemy.GetComponent<EnemyMovement>().patrol = false;
                Enemy.GetComponent<EnemyMovement>().followPlayer = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!crab)
            {
                Enemy.GetComponent<EnemyMovement>().patrol = true;
                Enemy.GetComponent<EnemyMovement>().followPlayer = false;
            }

            else
            {
                Enemy.GetComponent<CrabAI>().patrol = true;
                Enemy.GetComponent<CrabAI>().attackPlayer = false;
            }
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerBox : MonoBehaviour
{
    public GameObject Enemy;

    public Transform[] patrolPoints;

    public int waypointIndex = 0;

    public bool stopMoving;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy.transform.GetComponentInChildren<animationScript>().EnemyAttack(Random.Range(0, 3));
            stopMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            stopMoving = false;
        }
    }

    private void Update()
    {
        if(!stopMoving)
        {
            if (Vector3.Distance(Enemy.transform.position, patrolPoints[waypointIndex].position) < 2f)
            {
                IncreaseIndex();
            }
            else
            {
                // to the left of waypoint
                if (Enemy.transform.position.z < patrolPoints[waypointIndex].position.z)
                {
                    //Enemy.GetComponent<Rigidbody>().MovePosition(Vector3.forward);
                    Enemy.GetComponent<Rigidbody>().velocity = transform.forward * 2f;
                }

                // to the right of waypoint
                if (Enemy.transform.position.z > patrolPoints[waypointIndex].position.z)
                {
                    //Enemy.GetComponent<Rigidbody>().MovePosition(-Vector3.forward);
                    Enemy.GetComponent<Rigidbody>().velocity = -transform.forward * 2f;
                }
            }
        }
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= patrolPoints.Length)
        {
            waypointIndex = 0;
        }
    }
}

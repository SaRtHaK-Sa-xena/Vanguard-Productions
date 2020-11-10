using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardenAI : MonoBehaviour
{

    // animation handler
    public animationScript enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    public Transform playerTarget;

    public bool patrol;

    public Transform[] patrolPoints;
    private int waypointIndex;
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        patrol = true;

        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(patrol)
        {
            dist = Vector3.Distance(transform.position,
                patrolPoints[waypointIndex].position);

            if(dist < 4f)
            {
                IncreaseIndex();
            }
            Patrol();
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


    void Patrol()
    {
        // if the target is to the left
        if (patrolPoints[waypointIndex].position.z < transform.position.z)
        {
            Debug.Log("move right");
            myBody.velocity = transform.forward * speed;
        }
        
        // if the target is to the right
        if(patrolPoints[waypointIndex].position.z > transform.position.z)
        {
            Debug.Log("move left");
            myBody.velocity = -transform.forward * speed;
        }
    }
}

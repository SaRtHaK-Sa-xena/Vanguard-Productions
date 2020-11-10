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

    public bool patrol, attackPlayer;

    public Transform[] patrolPoints;
    private int waypointIndex;
    private float dist;

    // stunned variables
    private bool stunned;

    // attack variables
    private float currentAttackTime;
    private float defaultAttackTime = 5f;

    private float currentTimeTrack = 0;
    private float maxTime = 40f;

    // Start is called before the first frame update
    void Start()
    {
        patrol = true;
        attackPlayer = false;

        myBody = GetComponent<Rigidbody>();
        stunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
        {
            dist = Vector3.Distance(transform.position,
                patrolPoints[waypointIndex].position);

            if (dist < 4f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        else
        {
            Attack();
            //currentTimeTrack++;
            //if (currentTimeTrack >= maxTime)
            //{
            //    currentTimeTrack = 0;
            //    patrol = true;
            //}
        }
    }

    private void FixedUpdate()
    {
        if(!attackPlayer)
        {
            //FollowTarget();
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

    void FollowTarget()
    {
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

    void Attack()
    {
        myBody.velocity = Vector3.zero;

        if (!attackPlayer || stunned)
        {
            Debug.Log("Exit");

            // exit
            return;
        }

        currentAttackTime += Time.deltaTime;

        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(0,3));
            currentAttackTime = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            patrol = false;
            attackPlayer = true;
        }
    }
}

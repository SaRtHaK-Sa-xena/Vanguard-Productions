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

    // warden states
    public bool patrol, attackPlayer, followPlayer;

    public Transform[] patrolPoints;
    private int waypointIndex;
    private float dist, distanceToPlayer;

    // stunned variables
    private bool stunned;

    // attack variables
    private float currentAttackTime;
    private float defaultAttackTime = 5f;

    private float currentTimeTrack = 0;
    private float maxTime = 40f;

    // Cooldown 
    public bool CoolDown;
    private float coolDown = 0f;
    private float coolDownTracker = 200f;

    // Collision Check to see if player left
    private bool playerLeft;

    public float distanceToLeft = 7f;

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
            if(!followPlayer && attackPlayer)
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        // manages default attack time of warden
        if(attackPlayer)
        {
            if (enemyAnim.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                myBody.velocity = Vector3.zero;
                defaultAttackTime = 5f;
            }
            else
            {
                defaultAttackTime = 0.5f;
            }
        }

        // have cooldown before chasing player again.
        if (CoolDown)
        {
            coolDownTracker--;
            if (coolDownTracker < coolDown)
            {
                //track
                coolDownTracker = 150f;

                followPlayer = true;
                attackPlayer = false;
                CoolDown = false;
            }
        }

        if (followPlayer)
        {
            distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

            //Follow player
            FollowPlayer(distanceToPlayer);
        }
    }

    void FollowPlayer(float dist)
    {
        if (dist < 1)
        {
            patrol = false;
            attackPlayer = true;
            followPlayer = false;
        }
        else
        {
            if(playerTarget.position.z < transform.position.z)
            {
                //float distance = Vector3.Distance(transform.position, patrolPoints[0].position);
                //if(distance < distanceToLeft)
                //{

                //}
                //else
                //{
                    myBody.velocity = transform.forward * speed;
                ///}
            }
           
            if(playerTarget.position.z > transform.position.z)
            {
                //float distance = Vector3.Distance(transform.position, patrolPoints[1].position);
                //if (distance < 2f)
                //{

                //}
                //else
                //{
                    myBody.velocity = -transform.forward * speed;
                //}
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
            followPlayer = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Left");
            CoolDown = true;
            attackPlayer = false;
            //followPlayer = false;
        }
    }
}

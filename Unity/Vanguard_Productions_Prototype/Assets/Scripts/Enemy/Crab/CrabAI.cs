using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : MonoBehaviour
{
    // animation handler
    public animationScript enemyAnim;

    // rigidbody
    private Rigidbody myBody;
    
    // player target
    public Transform playerTarget;

    // jump attack variables
    public float jumpHeight = 12f;
    public float distanceFromPlayer;

    // sphere collider
    public SphereCollider col;
    
    // groundLayer
    [SerializeField] LayerMask groundLayers;


    // stagger and stun on player hit conditions
    public bool staggered, stunned;
    
    // stun variables
    public float stunnedTime, defaultStunnedTime;

    // Enemy Agent States
    public bool patrol, followPlayer, attackPlayer;

    // Attacking Variables
    private float currentAttackTime;
    private float defaultAttackTime = 2f;
    
    // distance in which the enemy will attack
    private float attackDistance = 5f;


    // patrol variables
    public Transform[] patrolPoints;

    // current waypoint index
    private int waypointIndex;
    public float dist;
    public float ForceToMove;

    // animation playing will be false
    private bool animationPlaying = false;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        stunnedTime = defaultStunnedTime;
        staggered = false;

        followPlayer = false;
        patrol = true;
        currentAttackTime = defaultAttackTime;

    }

    // GameObject Function
    private void Start()
    {
        waypointIndex = 0;

        // enemy z points to patrol point
        //transform.LookAt(patrolPoints[waypointIndex].position);

        col = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        if(myBody.velocity == Vector3.zero)
        {
           myBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

        distanceFromPlayer = playerTarget.position.z - transform.position.z;

        if (stunned)
        {
            // check if stun animation playing
            if (!animationPlaying)
            {
                // play enemy stun animation
                enemyAnim.GetComponent<animationScript>().Play_StunAnimation();

                // make attack player false
                attackPlayer = false;

                // set animation playing to true
                animationPlaying = true;
            }
        }

        // if not stunned
        else
        {
            // if enemy patrolling
            if(patrol)
            {
                dist = Vector3.Distance(transform.position,
                    patrolPoints[waypointIndex].position);

                if(dist < 1f)
                {
                    IncreaseIndex();
                }
                else
                {
                    if (dist > 3f)
                    {
                        ForceToMove = dist / 2f;
                    }
                    else
                    {
                        ForceToMove = dist;
                    }
                }
                Patrol();
            }
        }
    }

    // increase index in waypoint
    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= patrolPoints.Length)
        {
            waypointIndex = 0;
        }
    }

    // patrol AI
    void Patrol()
    {
        // move attack towards patrol point
        jumpAttack(0.5f, patrolPoints[waypointIndex]);
    }

    // Jumps to player Position
    public void jumpAttack(float distanceFromPoint, Transform Target)
    {
        if (IsGrounded())
        {
            //transform.LookAt(Target.position);
            //myBody.AddForce(new Vector3(0, jumpHeight, distanceFromPoint), ForceMode.Impulse);

            if (Target.position.z < transform.position.z)
            {
                myBody.AddForce(new Vector3(0, jumpHeight, -distanceFromPoint), ForceMode.Impulse);
            }
            else
            {
                myBody.AddForce(new Vector3(0, jumpHeight, distanceFromPoint), ForceMode.Impulse);
            }
        }
    }


    // ground check
    public bool IsGrounded()
    {
        return Physics.CheckCapsule
            (col.bounds.center, new Vector3
            (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius, groundLayers);
    }

}

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
    public float jumpHeight;
    public float attackHeight = 7.5f;
    public float defaultJumpHeight = 5f;
    public float distanceFromPlayer;

    // sphere collider
    public SphereCollider col;
    
    // groundLayer
    [SerializeField] LayerMask groundLayers;


    // stagger and stun on player hit conditions
    public bool staggered, stunned;
    
    // stun variables
    public float stunnedTime, defaultStunnedTime;
    public float timeTracker = 0;

    // Enemy Agent States
    public bool patrol, followPlayer, attackPlayer;

    // Attacking Variables
    private float currentAttackTime;
    private float defaultAttackTime = 1f;
    
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

    // extra int variable to move enemy if stuck
    private float offset = 2f;

    // condition to check to deal damage
    private bool turnOnAttack = false;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        stunnedTime = defaultStunnedTime;
        staggered = false;

        followPlayer = false;
        patrol = true;
        currentAttackTime = defaultAttackTime;

        // set jump height
        jumpHeight = defaultJumpHeight;

    }

    // GameObject Function
    private void Start()
    {
        waypointIndex = 0;

        col = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        if(!attackPlayer)
        {
            if (myBody.velocity == Vector3.zero)
            {
                myBody.AddForce(new Vector3(0, jumpHeight, offset), ForceMode.Impulse);
                offset = -offset;
            }
            jumpHeight = defaultJumpHeight;
        }
        
        
        // checks if enemy grounded
        if(IsGrounded())
        {
            // set bool to grounded
            enemyAnim.anim.SetBool("IsGround", true);

            // turn attack off
            turnOnAttack = false;
        }

        // find distance from player to enemy
        distanceFromPlayer = playerTarget.position.z - transform.position.z;

        // if enemy patrolling
        if (patrol)
        {
            // get distance between patrol point and enemy
            dist = Vector3.Distance(transform.position,
                patrolPoints[waypointIndex].position);

            // if on point
            if (dist < 1f)
            {
                // increase waypoint index
                IncreaseIndex();
            }

            // if not close to point
            else
            {
                // check if the distance greater than 3f
                if (dist > 3f)
                {
                    // make the movement slower
                    ForceToMove = dist / 2f;
                }

                // if it's close
                else
                {
                    // bring back original distance movement
                    ForceToMove = dist;
                }
            }

            // Run Patrol Evemt
            Patrol();
        }
        else
        {
            Attack();
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

    void Attack()
    {
        if (!attackPlayer || stunned)
        {
            return;
        }

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime > defaultAttackTime)
        {
            // reset attack time
            currentAttackTime = 0f;

            // attack can now deal damage
            turnOnAttack = true;

            jumpHeight = attackHeight;

            // jump to player
            //jumpAttack(distanceFromPlayer, playerTarget);
            if (playerTarget.position.z < transform.position.z)
            {
                myBody.AddForce(new Vector3(0, jumpHeight*2, distanceFromPlayer - 5), ForceMode.Impulse);
            }
            else
            {
                myBody.AddForce(new Vector3(0, jumpHeight * 2, distanceFromPlayer + 5), ForceMode.Impulse);
            }
            enemyAnim.anim.SetTrigger("Attack");
        }
    }


    // Jumps to player Position
    public void jumpAttack(float distanceFromPoint, Transform Target)
    {
        if (IsGrounded())
        {
            // play anim
            enemyAnim.crabAttack();

            // if the target is to the left of enemy
            if (Target.position.z < transform.position.z)
            {
                // move left
                myBody.AddForce(new Vector3(0, jumpHeight, -distanceFromPoint), ForceMode.Impulse);
            }

            // if target to the right of enemy
            else
            {
                // move right
                myBody.AddForce(new Vector3(0, jumpHeight, distanceFromPoint), ForceMode.Impulse);
            }

            // since in jump set ground to false
            enemyAnim.anim.SetBool("IsGround", false);
        }
    }

    public void TurnOffStun()
    {
        stunned = false;
        attackPlayer = true;

        staggered = false;

        animationPlaying = false;

        // check if stun particle exists
        if(transform.GetChild(1).transform.childCount < 0)
        {
            // destroy stun effect
            Destroy(transform.GetChild(1).transform.GetChild(0).gameObject);
        }
    }

    public void InvokeStun()
    {
        
    }

    // ground check
    public bool IsGrounded()
    {
        return Physics.CheckCapsule
            (col.bounds.center, new Vector3
            (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius, groundLayers);
    }


    // Handle Damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthScript>().ApplyDamage(10f, false);
        }
    }

}

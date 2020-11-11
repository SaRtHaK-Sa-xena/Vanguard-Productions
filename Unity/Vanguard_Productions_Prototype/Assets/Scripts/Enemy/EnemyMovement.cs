using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public animationScript enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    public Transform playerTarget;
    public GameObject Player;

    public bool patrol;
    public Transform[] patrolPoints;

    private int waypointIndex;
    private float dist;

    public float attack_Distance = 1f;
    private float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    public bool followPlayer, attackPlayer;

    public bool stunned; //Checked through Ranged Stun Attack Particle Script
    public float defaultStunnedTime; //manually edited in Editor
    public float stunnedTime; //used in game
    public float timeTracker = 0;
    public bool staggered;
    public bool jumped;

    public float jumpHeight = 12f;
    public float distanceFromPlayer;

    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayers;

    // checks if dead
    public bool dead;

    private bool animationPlaying = false;

    // Sphere collider
    public SphereCollider col;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();

        //playerTarget = GameObject.FindWithTag("Player").transform;

        // set stunned time to defaults
        stunnedTime = defaultStunnedTime;
        staggered = false;

        if(gameObject.name == "CrabBoy" || gameObject.name == "Warden")
        {
            patrol = false;
            followPlayer = false;
            attackPlayer = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
        patrol = true;
        current_Attack_Time = default_Attack_Time;

        waypointIndex = 0;
        transform.LookAt(patrolPoints[waypointIndex].position);

        col = GetComponent<SphereCollider>();

        if (gameObject.name == "CrabBoy" || gameObject.name == "Warden")
        {
            patrol = false;
            followPlayer = false;
            attackPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = playerTarget.position.z - transform.position.z;

        if (stunned)
        {
            if (!animationPlaying)
            {
                // play stun animation
                enemyAnim.GetComponent<animationScript>().Play_StunAnimation();

                // turn the movement anim to false
                enemyAnim.GetComponent<animationScript>().Walk(false);

                // set animation playing condition to true
                animationPlaying = true;
            }
            followPlayer = false;

            // patrol to false
            patrol = false;

            // start calculating time stunned
            timeTracker += 0.1f;

            // if the time exceeds stunned time cap
            if (timeTracker > stunnedTime)
            {
                // turn off stun
                TurnOffStun();

                // reset tracker
                timeTracker = 0;

                patrol = true;
                enemyAnim.GetComponent<animationScript>().Stop_StunAnimation();
            }
            return;
        }
        else
        {
            if (!patrol)
            {
                Attack();
                if(GetComponentInChildren<animationScript>())
                {
                    GetComponentInChildren<animationScript>().Stop_StunAnimation();
                    GetComponentInChildren<animationScript>().Walk(true);
                }
                animationPlaying = false;
            }
            else
            {
                dist = Vector3.Distance(transform.position,
                    patrolPoints[waypointIndex].position);

                if (dist < 1f)
                {
                    IncreaseIndex();
                }
                Patrol();
            }
        }
    }


    private void FixedUpdate()
    {
        if(!patrol)
        {
            FollowTarget();
        }
        else
        {
            Patrol();
        }
    }

    

    public void jumpAttack()
    {
        //float distanceFromPlayer = Vector3.Distance(playerTarget.position, transform.position);
        
        
        if(IsGrounded())
        {
            // if target position z less
            //if (playerTarget.position.z < transform.position.z)
            //{
            //    distanceFromPlayer = -distanceFromPlayer;
            //}

            // add force

            if (playerTarget.position.z < transform.position.z)
            {
                myBody.AddForce(new Vector3(0, jumpHeight, distanceFromPlayer - 5), ForceMode.Impulse);
            }
            else
            {
                myBody.AddForce(new Vector3(0, jumpHeight, distanceFromPlayer + 5), ForceMode.Impulse);
            }
        }
    }

    // Follow Target
    void FollowTarget()
    {
        // if to not follow player
        if (!followPlayer || stunned)
        {
            // exit
            return;
        }


        else if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            // if the enemy is not staggered
            if (!staggered)
            {
                // if target position z less
                if (playerTarget.position.z < transform.position.z)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                if (playerTarget.position.z > transform.position.z)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                myBody.velocity = transform.forward * speed;

                if (myBody.velocity.sqrMagnitude != 0)
                {
                    enemyAnim.Walk(true);
                }
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            // if enemy not staggered
            if (!staggered)
            {
                // set velocity to zero
                myBody.velocity = Vector3.zero;

                // stop playing walk
                enemyAnim.Walk(false);

                // turn follow to false
                // turn attack to true
                followPlayer = false;
                attackPlayer = true;
            }
        }
    }

    // Turn off stun and continue to follow player.
    public void TurnOffStun()
    {
        stunned = false;
        followPlayer = true;

        // check if the helper object has the
        // patrol symbol to true

        staggered = false;

        animationPlaying = false;

        if (transform.GetChild(1).transform.childCount > 0)
        {
            // Destroy Stun Effect
            Destroy(transform.GetChild(1).transform.GetChild(0).gameObject);
        }
    }

    // Attack Function
    void Attack()
    {
        // if not attacking
        if (!attackPlayer || stunned)
        {
            // exit
            return;
        }
        else
        {
            // do nothing
        }

        current_Attack_Time += Time.deltaTime;
        //Debug.Log("Current Attack Time: " + current_Attack_Time);

        if (current_Attack_Time > default_Attack_Time)
        {
            //Debug.Log("Now Attacking");

            enemyAnim.EnemyAttack(Random.Range(0, 3));

            current_Attack_Time = 0f;
        }

        // if patrol
        //if(!patrol)
        //{
        // too far then set follow player to true
        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
        //}
    }


    /// <summary>
    /// Make sure player survey rather than go for player
    /// Patrol targets
    /// </summary>
    public void Patrol()
    {
        if(gameObject.name != "Warden")
            myBody.transform.LookAt(patrolPoints[waypointIndex]);

        myBody.velocity = transform.forward * speed;

        if (myBody.velocity.sqrMagnitude != 0)
        {
            enemyAnim.Walk(true);
        }
    }


    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= patrolPoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(patrolPoints[waypointIndex].position);
    }


    public void InvokeStun()
    {
        Invoke("TurnOffStun", stunnedTime);
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule
            (col.bounds.center, new Vector3
            (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius, groundLayers);
    }
}
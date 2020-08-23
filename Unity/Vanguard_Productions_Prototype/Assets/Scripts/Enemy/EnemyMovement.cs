using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private animationScript enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attack_Distance = 1f;
    private float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    private bool followPlayer, attackPlayer;

    public bool stunned; //Checked through Ranged Stun Attack Particle Script
    public float defaultStunnedTime; //manually edited in Editor
    public float stunnedTime; //used in game
    public float timeTracker = 0;
    public bool staggered;
    public bool jumped;

    private bool animationPlaying = false;

    //  Enemy jumps
    public float smallEnemyJump = 10f;
    public float bigEnemyJump = 20f;

    // Sphere collider
    public SphereCollider col;

    // Layer mask
    public LayerMask groundLayers;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<animationScript>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag("Player").transform;

        // set stunned time to default
        stunnedTime = defaultStunnedTime;
        staggered = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsGrounded())
        {
            GetComponentInChildren<animationScript>().Walk(false);
        }

        if (stunned)
        {
            if (!animationPlaying)
            {
                // play stun animation
                GetComponentInChildren<animationScript>().Play_StunAnimation();

                // Debug Purposes
                Debug.Log("Play Animation");

                // turn the movement anim to false
                GetComponentInChildren<animationScript>().Walk(false);

                // set animation playing condition to true
                animationPlaying = true;
            }
            followPlayer = false;


            // start calculating time stunned
            timeTracker += 0.1f;

            // if the time exceeds stunned time cap
            if (timeTracker > stunnedTime)
            {
                // turn off stun
                TurnOffStun();

                // reset tracker
                timeTracker = 0;
            }
            return;
        }
        else
        {
            Attack();
            GetComponentInChildren<animationScript>().Stop_StunAnimation();
            GetComponentInChildren<animationScript>().Walk(true);
            animationPlaying = false;
        }
    }

    private void FixedUpdate()
    {
        if(IsGrounded())
        {
            jumped = false;
        }
        if(!jumped)
        {
            FollowTarget();
        }
    }

    // Follow Target
    void FollowTarget()
    {
        // if to not follow player
        if (!followPlayer)
        {
            // exit
            return;
        }

        else if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            //transform.LookAt(playerTarget);

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
        staggered = false;

        Debug.Log("Played!");

        //transform.GetChild(1).transform.GetChild(0).GetComponent<animationScript>().Stop_StunAnimation();

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
        if (!attackPlayer)
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

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider entered enemy trigger");

        if (other.CompareTag("small_jump"))
        {
            Debug.Log("small");
            jumped = true;
            //GetComponentInChildren<animationScript>().Walk(false);
            GetComponent<Rigidbody>().AddForce(Vector3.up * smallEnemyJump);
        }
        if(other.CompareTag("big_jump"))
        {
            Debug.Log("big");
            jumped = true;
            //GetComponentInChildren<animationScript>().Walk(false);
            GetComponent<Rigidbody>().AddForce(Vector3.up * bigEnemyJump);
        }
    }


    public bool IsGrounded()
    {
        return Physics.CheckCapsule
            (col.bounds.center, new Vector3
            (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * .9f, groundLayers);
    }

    public void JumpOverObstacle(string tag_obj)
    {
        // if the jump is small 
        if(tag_obj == "small_jump")
        {
        }

        // if the jump is big
        if (tag_obj == "big_jump")
        {
        }
    }


    public void InvokeStun()
    {
        Invoke("TurnOffStun", stunnedTime);
    }
}

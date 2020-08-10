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

    private bool animationPlaying = false;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<animationScript>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag("Player").transform;

        // set stunned time to default
        stunnedTime = defaultStunnedTime;
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
        if(stunned)
        {
            if(!animationPlaying)
            {
                GetComponentInChildren<animationScript>().Play_StunAnimation();
                Debug.Log("Play Animation");
                GetComponentInChildren<animationScript>().Walk(false);
                animationPlaying = true;
            }
            followPlayer = false;


            timeTracker += 0.1f;
            if(timeTracker > stunnedTime)
            {
                TurnOffStun();
                timeTracker = 0;
            }
            return;
            //Invoke("TurnOffStun", stunnedTime);
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
        FollowTarget();
    }

    // Follow Target
    void FollowTarget()
    {
        // if to not follow player
        if(!followPlayer)
        {
            // exit
            return;
        }

        else if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }


    public void InvokeStun()
    {
        Invoke("TurnOffStun", stunnedTime);
    }

    // Turn off stun and continue to follow player.
    public void TurnOffStun()
    {
        stunned = false;
        followPlayer = true;

        Debug.Log("Played!");

        //transform.GetChild(1).transform.GetChild(0).GetComponent<animationScript>().Stop_StunAnimation();

        if(transform.GetChild(1).transform.childCount > 0)
        {
            // Destroy Stun Effect
            Destroy(transform.GetChild(1).transform.GetChild(0).gameObject);
        }
    }

    void Attack()
    {
        // if not attacking
        if(!attackPlayer)
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

        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}

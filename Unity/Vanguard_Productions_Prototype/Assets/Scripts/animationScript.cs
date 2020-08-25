﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Animation For Player
/// </summary>
public class animationScript : MonoBehaviour
{
    public Animator anim;
    public float InputX;
    public float InputZ;

    private bool stopLightAttack;

    //private Vector3 characterOrientation;
    bool correctRotation = false;
    private CameraShake shakeCamera;

    private void Awake()
    {
        //if (gameObject.CompareTag("Particle"))
        //{
        //    Play_StunAnimation();
        //    Debug.Log("Play Stun");
        //}
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        //characterOrientation = transform.parent.eulerAngles;
    }

    private void Update()
    {

        shakeCamera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();

        if (FindObjectOfType<PlayerControl>().allowMovement == true)
        {
            if(gameObject.CompareTag("Player"))
            {
                // ====== side scroller movement ========
                //InputZ = Input.GetAxis("Vertical"); //UP and DOWN arrow key
                //anim.SetFloat("zMov", InputX);

                InputX = Input.GetAxis("Horizontal"); //LEFT and RIGHT arrow key
                anim.SetFloat("xMov", InputX);

                //  if player presses space bar
                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetTrigger("isJump");
                }
                // ====== side scroller movement ========

                // ====== Character Orientation =========

                //update character orientation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    //characterOrientation.y += 0.1f;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
                {
                    //InputZ = 0;
                    //InputX = 0;
                    anim.SetFloat("xMov", 0);
                    //return;
                }
            }
        }
    }

    // Animations For Attack

    // Light attacks
    public void light_1()
    {
        anim.SetTrigger("light_1");
    }

    // Light Attack 2
    public void light_2()
    {
        anim.SetTrigger("light_2");
    }


    // Light Attack 3
    public void light_3()
    {
        anim.SetTrigger("light_3");
    }

    public void heavyAttack()
    {
        anim.SetTrigger("heavyAttack");
    }

    public void GrappleHook()
    {
        anim.SetTrigger("Grappling_Hook");
    }

    public void Mid_Air_Attack()
    {
        anim.SetTrigger("Mid_Air_Attack");
    }

    // On enemy 
    public void ShakeCameraOnHit()
    {
        shakeCamera.setShouldShake(true);
    }
    
    // stop stagger on enemy
    public void stopStagger()
    {
       transform.parent.GetComponent<EnemyMovement>().staggered = false;
    }

    public void Play_Falling_Animation()
    {
        anim.SetBool("Falling", true);
    }

    public void Stop_Falling_Animation()
    {
        anim.SetBool("Falling", false);
    }

    //Enemy Animations
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger("Attack_1");
        }

        if (attack == 1)
        {
            anim.SetTrigger("Attack_2");
        }

        if (attack == 2)
        {
            anim.SetTrigger("Attack_3");
        }
    } // enemy attacks

    // Play Stunned Animation
    public void Play_StunAnimation()
    {
        anim.SetBool("Stunned", true);
    }

    public void Stop_StunAnimation()
    {
        anim.SetBool("Stunned", false);
    }

    public void Stun_Enemy()
    {
        transform.parent.GetComponent<EnemyMovement>().InvokeStun();
    }

    public void Play_IdleAnimation()
    {
        anim.Play("Idle");
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }

    public void Hit()
    {
        anim.SetTrigger("Hit");
    }

    public void RangedAttack()
    {
        anim.SetTrigger("Ranged_Attack");
    }

    public void Walk(bool move)
    {
        anim.SetBool("Movement", move);
    }
    
    // Helper Functions
    public void stopMovement()
    {
        // don't allow player to attack again
        FindObjectOfType<PlayerAttack>().attack = false;
    }

    public void allowMovement()
    {
        // allow player to attack again
        FindObjectOfType<PlayerAttack>().attack = true;
    }

    public void Shoot_Stun_Effect()
    {
        FindObjectOfType<Ranged_Attack>().Spawn_Stun_Attack();
    }

    // enable falling in jumpController Script
    public void enableFalling()
    {
        FindObjectOfType<jumpController>().falling = true;
    }

    public void freezePosition()
    {
        anim.speed = 0;
        Invoke("unfreeze", 0.5f);
    }

    void unfreeze()
    {
        anim.speed = 1;
    }
}

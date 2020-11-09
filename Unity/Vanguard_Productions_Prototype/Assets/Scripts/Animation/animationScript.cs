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

    PlayerControls animationControls;

    private void Awake()
    {
        animationControls = new PlayerControls();

        // Jump
        animationControls.Gameplay.Jump.performed += _ => Jump();

        //animationControls.Animation.Running.performed += ctx => move = ctx.ReadValue<Vector2>();
        //animationControls.Animation.Running.canceled += ctx => move = Vector2.zero;

        //if (gameObject.CompareTag("Particle"))
        //{
        //    Play_StunAnimation();
        //    Debug.Log("Play Stun");
        //}
    }

    private void OnEnable()
    {
       animationControls.Animation.Enable();
       animationControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
       animationControls.Animation.Disable();
       animationControls.Gameplay.Disable();
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
            // if script on player
            if (gameObject.CompareTag("Player"))
            {
                

                // if key mapping set to wasd
                if (transform.parent.GetComponent<PlayerControl>().wasd)
                {
                    InputX = animationControls.Animation.Running.ReadValue<float>();

                    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                    {

                    }
                    else
                    {
                        InputX = Input.GetAxisRaw("Horizontal");
                    }

                    anim.SetFloat("xMov", InputX);


                    // if both movement directions pressed
                    if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                    {
                        //InputZ = 0;
                        //InputX = 0;
                        InputX = 0f;
                        anim.SetFloat("xMov", InputX);
                        return;
                    }

                    // ====== Character Orientation =========
                    //update character orientation
                    if (Input.GetKey(KeyCode.A) || InputX < 0)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        FindObjectOfType<Ranged_Attack>().Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, 0, 0);
                        FindObjectOfType<Ranged_Attack>().spawnPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                        //characterOrientation.y += 0.1f;
                    }
                    else if (Input.GetKey(KeyCode.D) || InputX > 0)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        FindObjectOfType<Ranged_Attack>().Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, 0, 0);
                        FindObjectOfType<Ranged_Attack>().spawnPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }
                else
                {
                    InputX = animationControls.Animation.Running.ReadValue<float>();

                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("Pressing A");
                    }
                    else
                    {
                        InputX = Input.GetAxisRaw("Horizontal");
                    }

                    anim.SetFloat("xMov", InputX);

                    // if both movement directions pressed
                    if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                    {
                        //InputZ = 0;
                        //InputX = 0;
                        InputX = 0f;
                        anim.SetFloat("xMov", InputX);
                        return;
                    }

                    // ====== Character Orientation =========
                    //update character orientation
                    if (Input.GetKey(KeyCode.LeftArrow) || InputX < 0)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        FindObjectOfType<Ranged_Attack>().Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, 0, 0);
                        FindObjectOfType<Ranged_Attack>().spawnPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                        //characterOrientation.y += 0.1f;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow) || InputX > 0)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        FindObjectOfType<Ranged_Attack>().Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, 0, 0);
                        FindObjectOfType<Ranged_Attack>().spawnPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }
            }
        }
    }

    // Jump Function
    public void Jump()
    {
        anim.SetTrigger("isJump");
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
        anim.SetBool("Grappling", true);
    }

    public void StopGrapple()
    {
        anim.SetBool("Grappling", false);
    }

    public void Mid_Air_Attack()
    {
        anim.SetTrigger("Mid_Air_Attack");
    }

    public void setPlayerOnFloor()
    {
        anim.SetTrigger("IsGround");
    }

    // On enemy 
    public void ShakeCameraOnHit()
    {
        shakeCamera.setShouldShake(true);
    }
    
    // Death 
    public void DeleteEnemy()
    {
        Destroy(this.gameObject);
    }

    // stop stagger on enemy
    public void stopStagger()
    {
       transform.parent.GetComponent<EnemyMovement>().staggered = false;
    }


    // play stagger effect
    public void playStaggerEffect()
    {
        GameObject rigidBodyObj = transform.parent.gameObject;
        Debug.Log("Working");
        rigidBodyObj.GetComponent<Rigidbody>().AddForce(rigidBodyObj.transform.up * 300f);
        rigidBodyObj.GetComponent<Rigidbody>().AddForce(-rigidBodyObj.transform.forward * 600f);
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

    // KnockBack

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

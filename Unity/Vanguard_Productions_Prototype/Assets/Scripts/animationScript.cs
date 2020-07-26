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

    private void Start()
    {
        anim = GetComponent<Animator>();
        //characterOrientation = transform.parent.eulerAngles;
    }

    private void Update()
    {
        if (FindObjectOfType<PlayerControl>().allowMovement == true)
        {
            // ====== side scroller movement ========
            InputZ = Input.GetAxis("Vertical"); //UP and DOWN arrow key
            InputX = Input.GetAxis("Horizontal"); //LEFT and RIGHT arrow key
            anim.SetFloat("xMov", InputX);
            anim.SetFloat("zMov", InputX);

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
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                //correctRotation = true;
            }
        }
    }

    // Animations For Attack
    public void lightAttack()
    {
        anim.SetTrigger("lightAttack");
    }

    public void heavyAttack()
    {
        anim.SetTrigger("heavyAttack");
    }

    //Enemy Animations
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger("Attack 1");
        }

        if (attack == 1)
        {
            anim.SetTrigger("Attack 2");
        }

        if (attack == 2)
        {
            anim.SetTrigger("Attack 3");
        }
    } // enemy attacks

    public void Play_IdleAnimation()
    {
        anim.Play("Idle");
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
}

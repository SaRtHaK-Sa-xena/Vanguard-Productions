using System.Collections;
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

    //  distance to ground
    float distanceToGround = 12.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
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


            //InputZ = Input.GetAxis("Vertical"); //UP and DOWN arrow key
            //InputX = Input.GetAxis("Horizontal"); //LEFT and RIGHT arrow key

            ////if(Input.GetKeyDown(KeyCode.A))
            ////{
            ////    InputZ -= 0.1f;
            ////}
            ////if(Input.GetKeyDown(KeyCode.D))
            ////{
            ////    InputZ += 0.001f;
            ////}
            ////else
            ////{

            ////}

            ////  Pass values through animator
            //anim.SetFloat("InputZ", InputZ);
            //anim.SetFloat("InputX", InputX);

            //Debug.Log("InputZ: " + InputZ);
            //Debug.Log("InputX: " + InputX);

            ////  if player presses space bar
            //if (Input.GetButtonDown("Jump"))
            //{
            //    anim.SetTrigger("isJump");
            //}
        }

        //Only for Open-World Sim
        #region Free Fall Anim

        ////  if player is above ground by a certain distance, play freefall anim
        //RaycastHit rayCast;
        //if (Physics.Raycast(transform.position, Vector3.down, out rayCast, 0.10f))
        //{
        //    //if collision
        //    //set free fall to false
        //    anim.SetBool("isFalling", false);
        //}
        //else
        //{
        //    //if no collision
        //    //set free fall to true
        //    anim.SetBool("isFalling", true);
        //}

        #endregion
    }
}

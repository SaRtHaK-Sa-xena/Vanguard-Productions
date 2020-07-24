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

    private Vector3 characterOrientation;

    bool correctRotation = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterOrientation = transform.parent.eulerAngles;
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
                transform.eulerAngles = new Vector3(0,180,0);
                //characterOrientation.y += 0.1f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0,0,0);
            }
            else
            {
                //correctRotation = true;
            }

            // update orientation
            transform.parent.eulerAngles = characterOrientation;

            // ====== Character Orientation =========


            if (correctRotation)
            {
                Vector3 finalPoint = new Vector3(0, 0, 0);
                if(Vector3.Distance(transform.eulerAngles, finalPoint) > 0.01f)
                {
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, finalPoint, Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = finalPoint;
                    correctRotation = false;
                }
            }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // player
    public GameObject player;
    public GameObject rayCastPos;

    public float force;

    private PlayerEngine engine;

    public float speed;
    public bool inCollision;
    public Vector3 a_Velocity;

    public bool display;

    private Vector3 norm;
    private float mouseHor;

    public GameObject rayCastFeet;

    private void Start()
    {
        engine = GetComponent<PlayerEngine>();
    }

    private void Update()
    {
        mouseHor = Input.GetAxisRaw("Horizontal");
        if (mouseHor < 0)
            rayCastFeet.transform.eulerAngles = new Vector3(0, 180, 0);
        else
            rayCastFeet.transform.eulerAngles = new Vector3(0, 0, 0);

        // if player running right, and contact norm pointing left               
        if (mouseHor == norm.z)
        {
            GetComponent<PlayerControl>().allowMovement = true;
            //player.GetComponent<Rigidbody>().AddForce(norm * force * Time.deltaTime);
            //transform.GetChild(0).GetComponent<animationScript>().anim.SetFloat("xMov", 0);
        }



        // ==== create ray cast from feet
        // ==== create when player jumped
        // ==== if(nothing in front)
        // ==== turn movement to true
        if(!GetComponent<jumpController>().IsGrounded())
        {
            RaycastHit info;
            if (Physics.Raycast(rayCastFeet.transform.position, rayCastFeet.transform.TransformDirection(Vector3.forward), out info, 5f))
            {
                // Debug To check
                //Debug.Log("Ray Hit Something");
                //Debug.DrawRay(rayCastFeet.transform.position, rayCastFeet.transform.TransformDirection(Vector3.forward) * info.distance, Color.green);
                //Debug.Log(info.collider.tag);
                if(!info.collider.CompareTag("Wall"))
                {
                    GetComponent<PlayerControl>().allowMovement = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // if tagged wall then add force
            norm = collision.contacts[0].normal;
        }

        // if normal point right or left
        Vector3 zVector = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 zNegVector = new Vector3(0.0f, 0.0f, -1.0f);

        if(norm == zVector || norm == zNegVector)
        {
            //Debug.Log("Norm: " + norm);
            //player.GetComponent<Rigidbody>().AddForce(norm * force * Time.deltaTime);
            //GetComponent<PlayerControl>().allowMovement = false;
        }

        //Debug.Log(ReturnDirection(collision.gameObject, this.gameObject));

        RaycastHit rayInfo;

        Vector3 direction = collision.contacts[0].point - rayCastPos.transform.position;

    }

    private void OnCollisionStay(Collision collision)
    {
        // if normal point right or left
        Vector3 zVector = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 zNegVector = new Vector3(0.0f, 0.0f, -1.0f);
       
        //if (norm == zVector || norm == zNegVector)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                // if player running right, and contact norm pointing left
                // if (norm.y == 1 || norm.y == -1)
                // return;

                // mouse horz > 0 && norm.z < 0

                if (norm.z > 0)
                    norm.z = 1;
                else if (norm.z < 0)
                    norm.z = -1;

                if (mouseHor != norm.z)
                {               
                    transform.GetChild(0).GetComponent<animationScript>().anim.SetFloat("xMov", 0);
                    GetComponent<PlayerControl>().allowMovement = false;
                    
                    //if(Input.GetKeyDown(KeyCode.Space))
                    //{
                    //    player.GetComponent<Rigidbody>().AddForce(player.transform.up * force * Time.deltaTime);
                    //}
                }

                if (norm.z == 0)
                {
                    GetComponent<PlayerControl>().allowMovement = true;
                }

                //if(!GetComponent<PlayerControl>().allowMovement)
                //{
                //    if (GetComponent<jumpController>().IsGrounded() && !Input.GetKeyDown(KeyCode.Space))
                //    {
                //        player.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * force * Time.deltaTime);
                //        Debug.Log("No JUmp up!");
                //    }
                //    else if(GetComponent<jumpController>().IsGrounded() && Input.GetKeyDown(KeyCode.Space))
                //    {
                //        player.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * (force * 200) * Time.deltaTime);
                //        player.GetComponent<Rigidbody>().AddForce(player.transform.up * force * Time.deltaTime);
                //        Debug.Log("Jump up!");
                //    }
                //}
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // if player exits collision on wall
        // set velocity of z to 0
        if (collision.gameObject.CompareTag("Wall"))
        {
           norm.z = 0;

            // if tagged wall then add force
            //norm = collision.contacts[0].normal;
            //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0);
            //player.GetComponent<Rigidbody>().AddForce(transform.up * force * Time.deltaTime);
            // GetComponent<PlayerControl>().allowMovement = true;
        }
    }



    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right}
    
    
    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {
        // set Hit Direction to none
        HitDirection hitDirection = HitDirection.None;
        
        // create raycast output
        RaycastHit MyRayHit;
        
        // get direction of collision object and player
        Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
        
        // create ray which points from the object hit position, to direction of player
        Ray MyRay = new Ray(ObjectHit.transform.position, direction);

        // display ray
        Debug.DrawRay(ObjectHit.transform.position, direction, Color.red, 5f);

        // ray cast using created ray with output of MyRayHit
        if (Physics.Raycast(MyRay, out MyRayHit))
        {
            // if ray hits something
            if (MyRayHit.collider != null)
            {
                // get normal of ray
                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                //if (MyNormal == MyRayHit.transform.up) {
                //    hitDirection = HitDirection.Top;

                //}
                //if (MyNormal == -MyRayHit.transform.up)
                //{ 
                //    hitDirection = HitDirection.Bottom;
                //}
                if (MyNormal == MyRayHit.transform.forward)
                {
                    hitDirection = HitDirection.Forward;

                    // add force on player relative to the normal of collision face.

                    // since the player hits left and right face of wall the norm will work accordingly
                    //player.GetComponent<Rigidbody>().AddForce(norm * force);
                }
                if (MyNormal == -MyRayHit.transform.forward)
                {
                    hitDirection = HitDirection.Back;
                }
                //if (MyNormal == MyRayHit.transform.right)
                //{
                //    hitDirection = HitDirection.Right;
                //}
                //if (MyNormal == -MyRayHit.transform.right)
                //{
                //    hitDirection = HitDirection.Left;
                //}
            }
        }
        
        return hitDirection;
    }
}

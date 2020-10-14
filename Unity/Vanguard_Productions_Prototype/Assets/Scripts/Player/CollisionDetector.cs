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


    private void Start()
    {
        engine = GetComponent<PlayerEngine>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if tagged wall then add force
        norm = collision.contacts[0].normal;

        // if normal point right or left
        Vector3 zVector = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 zNegVector = new Vector3(0.0f, 0.0f, -1.0f);

        if(norm == zVector || norm == zNegVector)
        {
            Debug.Log("Norm: " + norm);
            //player.GetComponent<Rigidbody>().AddForce(norm * force * Time.deltaTime);
            GetComponent<PlayerControl>().allowMovement = false;
        }

        //Debug.Log(ReturnDirection(collision.gameObject, this.gameObject));

        RaycastHit rayInfo;

        Vector3 direction = collision.contacts[0].point - rayCastPos.transform.position;

        //if(Physics.Raycast(rayCastPos.transform.position, transform.forward, out rayInfo))
        //{
        //    if(rayInfo.collider)
        //    {
        //        Debug.DrawRay(rayCastPos.transform.position, collision.contacts[0].point, Color.green, 5f);
        //    }
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            player.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * force * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // if player exits collision on wall
        // set velocity of z to 0
        if (collision.gameObject.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0);
            player.GetComponent<Rigidbody>().AddForce(transform.up * force * Time.deltaTime);
            GetComponent<PlayerControl>().allowMovement = true;
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


    public void SetForce(Vector3 m_Velocity)
    {

        //player.GetComponent<PlayerControl>().allowMovement = true;

        // or Left
        // Put Force Left
        //player.GetComponent<Rigidbody>().AddForce(Vector3.left * 20, ForceMode.Impulse);


        //Vector3 back = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + force);

        //GetComponent<Rigidbody>().MovePosition(back);


        //==================Previous Attempt ===================================================
        //Vector3 back = new Vector3(0, 0, player.transform.position.z - 0.01f);

        //a_Velocity = GetComponent<PlayerControl>().publicVelocity;

        //engine.Move(a_Velocity);

        //GetComponent<PlayerControl>().allowMovement = false;
        //GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0);

        //player.GetComponent<PlayerControl>().allowMovement = false;
        //player.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);

        //player.transform.position += back;
        //==================Previous Attempt ===================================================

        //player.GetComponent<Rigidbody>().AddForce(Vector3.right * force * Time.deltaTime, ForceMode.Impulse);


        //if(hitDirection == HitDirection.None)
        //{
        //    player.GetComponent<Rigidbody>().AddForce(Vector3.right* 20, ForceMode.Impulse);
        //}
    }
}

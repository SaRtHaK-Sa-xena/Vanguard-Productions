using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // on object
    public BoxCollider BC;

    // player
    public GameObject player;

    public float force;

    private void Start()
    {
        // get box collider
        BC = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(ReturnDirection(collision.gameObject, this.gameObject));
        player.GetComponent<PlayerControl>().allowMovement = false;
    }

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right}
    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {
        HitDirection hitDirection = HitDirection.None;
        RaycastHit MyRayHit;
        Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
        Ray MyRay = new Ray(ObjectHit.transform.position, direction);

        Debug.DrawRay(ObjectHit.transform.position, direction, Color.red);

        if (Physics.Raycast(MyRay, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {

                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up) {
                    hitDirection = HitDirection.Top;
                    // or Left
                    // Put Force Left
                    player.GetComponent<Rigidbody>().AddForce(Vector3.left * 20, ForceMode.Impulse);
                }
                if (MyNormal == -MyRayHit.transform.up)
                { 
                    hitDirection = HitDirection.Bottom;
                }
                if (MyNormal == MyRayHit.transform.forward)
                {
                    hitDirection = HitDirection.Forward;
                    //Vector3 back = new Vector3(0, 0, player.transform.position.z - 0.01f);
                    //player.GetComponent<PlayerControl>().allowMovement = false;
                    player.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
                    //player.transform.position += back;

                }
                if (MyNormal == -MyRayHit.transform.forward)
                {
                    player.GetComponent<Rigidbody>().AddForce(Vector3.right * force * Time.deltaTime, ForceMode.Impulse);
                    hitDirection = HitDirection.Back;
                }
                if (MyNormal == MyRayHit.transform.right)
                {
                    hitDirection = HitDirection.Right;
                }
                if (MyNormal == -MyRayHit.transform.right)
                {
                    hitDirection = HitDirection.Left;
                }
            }
        }
        //if(hitDirection == HitDirection.None)
        //{
        //    player.GetComponent<Rigidbody>().AddForce(Vector3.right* 20, ForceMode.Impulse);
        //}
        return hitDirection;
    }
}

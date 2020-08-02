using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Test_Script : MonoBehaviour
{

    public Transform end_point;
    public Transform startPoint;

    public float speed = 9999f;

    public float distance = 5f;

    public bool move;

    private float scalar = 2;

    public Animator anim;
    public animationScript playerAnim;

    public GameObject obj_Collider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        playerAnim = GetComponentInChildren<animationScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Set Move to true
            move = true;

            // Play Grappling Hook Anim
            playerAnim.GrappleHook();
        }

        

        if(move)
        {
            scalar += 0.5f;

            if(Input.GetKeyDown(KeyCode.F))
            {
                move = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
                unFreezePosition();
            }
            

            if(Vector3.Distance(end_point.position, transform.position) < distance)
            {
                move = false;
                scalar = 2;
                unFreezePosition();
                obj_Collider.GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, end_point.position, Time.deltaTime * (speed * scalar));

        }
    }

    public void unFreezePosition()
    {
        anim.speed = 1;
    }
}

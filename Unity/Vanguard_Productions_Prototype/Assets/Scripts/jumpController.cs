using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpController : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private float jumpVelocity;

    public LayerMask groundLayers;
    public float jumpForce = 6;
    public SphereCollider col;
    public Rigidbody rb;

    public animationScript anim;
    public bool falling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        anim = GetComponentInChildren<animationScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
        }

        if(rb.velocity.y < 0f)
        {
            falling = true;
            Debug.Log("Falling");
        }

        if(falling)
        {
            anim.Play_Falling_Animation();
        }
        if(IsGrounded())
        {
            if(falling)
            {
                anim.Stop_Falling_Animation();
                falling = false;
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule
            (col.bounds.center, new Vector3
            (col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * .9f, groundLayers);
    }
}

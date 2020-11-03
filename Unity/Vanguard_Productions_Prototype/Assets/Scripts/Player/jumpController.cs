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

    public bool jumpRequest;

    private PlayerControls controller;
    public ControlManager CM;

    public float MaxVelocity;

    // Debug Check Player Collision
    public GameObject box;

    private void OnEnable()
    {
        controller.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controller.Gameplay.Disable();
    }

    private void Awake()
    {
        controller = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        anim = GetComponentInChildren<animationScript>();

        // set jump settings
        controller.Gameplay.Jump.performed += context => Jump();
    }


    // Update is called once per frame
    void Update()
    {
        //if(GetComponent<PlayerControl>().allowMovement)
        //{
            if (IsGrounded() && Input.GetKeyDown(CM.jump))
            {
                jumpRequest = true;
                //GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
            }
        //}
        

        if(rb.velocity.y < 0f)
        {
            falling = true;
            //Debug.Log("Falling");
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

        //Vector3 v = rb.velocity;
        //v.y = 0;
        //v = Vector3.ClampMagnitude(v, MaxVelocity);
        //v.y = rb.velocity.y;
        //rb.velocity = v;
    }


    // Better Jumping
    private void FixedUpdate()
    {
        //if (GetComponent<PlayerControl>().allowMovement)
        //{
        if (jumpRequest)
        {
            // jump
            anim.Jump();

            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);

            // Set velocity of z to zero
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0);

            jumpRequest = false;
        }
        //}
        
    }

    public void Jump()
    {
        if(IsGrounded())
        {
            jumpRequest = true;
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

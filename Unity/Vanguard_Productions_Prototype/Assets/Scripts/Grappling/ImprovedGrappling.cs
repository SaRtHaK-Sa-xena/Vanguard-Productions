using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedGrappling : MonoBehaviour
{
    private LineRenderer lr;
    
    public Transform gunTip, player, grapplePoint;
    private float maxDistance = 1000f;
    private SpringJoint joint;

    // Changable Through editor
    public bool autoConfigure;
    public float damper, spring, massScale;

    public bool grappable;

    PlayerControls controller;

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
        lr = GetComponent<LineRenderer>();
        grappable = false;
        controller = new PlayerControls();
        
        controller.Gameplay.GrappleHook.performed += context => startGrapple();
        controller.Gameplay.GrappleHook.canceled += context => stopGrapple();
    }

    // Start is called before the first frame update
    void Start()
    {
        autoConfigure = false;
        //spring = 0f;
        //damper = 6f;
        //massScale = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (grappable)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                startGrapple();
            }
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            stopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void startGrapple()
    {
        if(grappable)
        {
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = autoConfigure;
            joint.connectedAnchor = grapplePoint.position;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint.position);

            joint.maxDistance = distanceFromPoint * 0.0f;
            joint.maxDistance = distanceFromPoint * 0.25f;

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;
        }
    }

    void jointUpdate()
    {
        joint.autoConfigureConnectedAnchor = autoConfigure;

        joint.spring = spring;
        joint.damper = damper;
        joint.massScale = massScale;
    }

    /// <summary>
    /// Destroy Joint and remove line
    /// </summary>
    void stopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }


    /// <summary>
    /// Draws Rope through Line renderer
    /// </summary>
    void DrawRope()
    {
        if (!joint)
        {
            return;
        }
        else
        {
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplePoint.position);
        }
    }
}

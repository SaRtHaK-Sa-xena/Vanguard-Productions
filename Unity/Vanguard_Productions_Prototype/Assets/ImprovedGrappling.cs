﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedGrappling : MonoBehaviour
{
    private LineRenderer lr;
    
    public Transform gunTip, player, grapplePoint;
    private float maxDistance = 1000f;
    private SpringJoint joint;

    public bool autoConfigure;
    public float damper, spring, massScale;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        autoConfigure = false;
        spring = 4.5f;
        damper = 7f;
        massScale = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        jointUpdate();
        if(Input.GetKeyDown(KeyCode.E))
        {
            startGrapple();
        }
        if(Input.GetKeyUp(KeyCode.E))
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
        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint.position;

        float distanceFromPoint = Vector3.Distance(player.position, grapplePoint.position);

        joint.maxDistance = distanceFromPoint * 0.0f;
        joint.maxDistance = distanceFromPoint * 0.25f;

        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        lr.positionCount = 2;
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

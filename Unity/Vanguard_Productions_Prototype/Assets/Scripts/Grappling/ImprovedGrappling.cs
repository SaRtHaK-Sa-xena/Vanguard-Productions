using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedGrappling : MonoBehaviour
{
    private LineRenderer lr;
    
    public Transform gunTip, player, grapplePoint;
    private float maxDistance = 1000f;
    private SpringJoint joint;

    public SpringJoint referenceJoint;

    // Changable Through editor
    public bool autoConfigure;
    public float damper, spring, massScale;

    public bool grappable;

    PlayerControls controller;

    Vector3 lastPos = new Vector3();
    float moveSpeed;

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
        
        // Controller settings
        controller = new PlayerControls();
        controller.Gameplay.GrappleHook.performed += context => startGrapple();
        controller.Gameplay.GrappleHook.canceled += context => stopGrapple();
    }

    // Start is called before the first frame update
    void Start()
    {
        autoConfigure = false;
        spring = 30f;
        damper = 6f;
        massScale = 4.5f;

        StartCoroutine(CalcVelocity());
    }

    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            lastPos = player.transform.position;
            yield return new WaitForFixedUpdate();
            moveSpeed = Mathf.RoundToInt(Vector3.Distance(player.transform.position, lastPos) / Time.fixedDeltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grappable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startGrapple();
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            stopGrapple();
        }
    }

    /// <summary>
    /// Debug Grapple Test #1
    /// Assign the 'E' command to set a boolean to true on hold
    /// if value true then create grapple
    /// else remove grapple
    /// </summary>


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

            // distance grapple will try to keep player away from grapple point
            joint.maxDistance = distanceFromPoint * 0.00f; //20
            joint.minDistance = distanceFromPoint * 0.50f;

            if(distanceFromPoint <= 5f)
            {
                joint.spring = 3f;
                Debug.Log("Reduce Spring");
            }

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;

            referenceJoint = joint;
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

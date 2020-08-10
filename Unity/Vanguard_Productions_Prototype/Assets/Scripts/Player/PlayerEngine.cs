using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

/// <summary>
/// Handles Player Physics With The World. Most Of This Was Used To Create A Basic Understanding of the Players Movement
/// and How it can be Changed To Effect Player Physics. This Was Used As A Starting Point. Only Rotation And Mouse Vectors
/// Are Being Used As The Movement Has Been Removed.
/// </summary>
public class PlayerEngine : MonoBehaviour
{
    [SerializeField]
    public Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    

    private Rigidbody rb;


    //Get Componenet RigidBody
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //inititate Move
    public void Move(Vector3 m_velocity)
    {
        velocity = m_velocity;
    }

    //inititate Rotation
    //public void Rotate(Vector3 m_rotation)
    //{
    //    rotation = m_rotation;
    //}

    //inititate Rotation For Camera
    //public void RotateCamera(Vector3 m_cameraRotation)
    //{
    //    cameraRotation = m_cameraRotation;
    //}

    //Perform Upon Fixed
    private void FixedUpdate()
    {
        if(FindObjectOfType<PlayerControl>().allowMovement == true)
        {
            ExecMovement();
           //ExecRotation();
        }
    }

    //Makes Player Move On Velocity, From Position According To Velocity Working with Fixed DeltaTime
    void ExecMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //RotatesUsing Euler, and transform Existing To transformed Rotation
    //void ExecRotation()
    //{
    //    rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    //    if (cam != null)
    //    {
    //        // - is used to inverse effect
    //        cam.transform.Rotate(-cameraRotation);
    //    }
    //}
}

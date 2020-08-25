using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    // animation
    public Animator cameraAnim;

    // position
    public float Player_z;

    // Player obj
    public GameObject Player_obj;

    // get camera animation
    private void Start()
    {
        cameraAnim = GetComponent<Animator>();
    }


    private void Update()
    {
        // player z position
        Player_z = Player_obj.transform.position.z;

        // Correctly play animation
        DelegateAnimation(Player_z);
    }

    // assigns correct animation for camera view
    // based on player position
    public void DelegateAnimation(float position)
    {
        // how to determine the position
    }
}

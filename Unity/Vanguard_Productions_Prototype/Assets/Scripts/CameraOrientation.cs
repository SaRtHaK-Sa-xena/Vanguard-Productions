using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrientation : MonoBehaviour
{
    public Vector3 fixedRotation;
    public Vector3 fixedPosition;

    public Transform player_Obj;

    private float startTime;

    private void Start()
    {
        fixedRotation.x = 13.507f;
        fixedRotation.y = -90.00f;
        fixedRotation.z = 0f;

        fixedPosition.x = 5.79f;
        fixedPosition.y = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //fixedPosition.z = transform.position.z;

        //transform.eulerAngles = fixedRotation;
        //transform.position.Set(fixedPosition.x, fixedPosition.y, fixedPosition.z);// = fixedPosition;


        // Update Camera To Move with Player
        transform.position = Vector3.Lerp(transform.position, //current position
            new Vector3(transform.position.x, // new position
            transform.position.y,
            player_Obj.transform.position.z), 3f * Time.deltaTime); 

    }
}

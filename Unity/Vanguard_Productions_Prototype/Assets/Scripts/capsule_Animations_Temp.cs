using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule_Animations_Temp : MonoBehaviour
{
    public Transform end_point;
    public Transform startPoint;

    public float speed = 9999f;

    public float distance = 2f;

    public bool move;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            move = true;
            transform.position = startPoint.position;
        }

        if(move)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                move = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
            

            if(Vector3.Distance(end_point.position, transform.position) < distance)
            {
                move = false;
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, end_point.position, Time.deltaTime * speed);

        }
    }
}

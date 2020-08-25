using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_Grapple : MonoBehaviour
{
    // get reference of grapple point
    public GameObject GrapplePoint;

    public GameObject Player;

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 1.5f)
        {
            Debug.Log("Near Grapple Helper");
        }
    }
}

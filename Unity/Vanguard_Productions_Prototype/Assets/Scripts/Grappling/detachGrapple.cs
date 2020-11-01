using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detachGrapple : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        // if player
        if(other.CompareTag("Player"))
        {
            other.GetComponent<ImprovedGrappling>().grappable = true;
            Destroy(other.GetComponent<SpringJoint>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_Grapple : MonoBehaviour
{
    // get reference of grapple point From Editor
    public GameObject GrapplePoint;

    public GameObject Player;

    // Sphere Collider
    SphereCollider col;

    private void Start()
    {
        col = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        //if (Vector3.Distance(Player.transform.position, transform.position) < 1.5f)
       //{
           //Debug.Log("Near Grapple Helper");
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        // If player in the area
        if(other.CompareTag("Player"))
        {

            if (!Input.GetKeyDown(KeyCode.X)) return;

            //assign the grapple Point to the grapple script
            FindObjectOfType<ImprovedGrappling>().grappable = true;

            FindObjectOfType<ImprovedGrappling>().grapplePoint = GrapplePoint.transform;
        }
    }
    // When player leaves the player cannot grapple
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<ImprovedGrappling>().grappable = false;
        }
    }

}

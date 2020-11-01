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

    GameObject m_other;

    [SerializeField] private float inRange = 1f;
    
    private bool startChecking;

    public GameObject UIAboveGrapple;

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

        //if(Input.GetKeyUp(KeyCode.X))
        //{
        //    FindObjectOfType<ImprovedGrappling>().grappable = false;
        //    Destroy(m_other.GetComponent<SpringJoint>());
        //}

        if (Input.GetKeyUp(KeyCode.X) && FindObjectOfType<ImprovedGrappling>().grappable)
        {
            FindObjectOfType<ImprovedGrappling>().grappable = false;
            Destroy(Player.GetComponent<SpringJoint>());
            Debug.Log("Remove Spring");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
        }
        //{
        //    if (!Input.GetKeyDown(KeyCode.X)) 
        //    {
        //        //Debug.Log("Not Holding X [OnTriggerEnter]");
        //        FindObjectOfType<ImprovedGrappling>().grappable = false;
        //        return;
        //    }

        //    //assign the grapple Point to the grapple script
        //    FindObjectOfType<ImprovedGrappling>().grappable = true;

        //    FindObjectOfType<ImprovedGrappling>().grapplePoint = GrapplePoint.transform;
        //}

    }

    private void OnTriggerStay(Collider other)
    {
        // If player in the area
        if(other.CompareTag("Player"))
        {
            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    startChecking = true;
            //}

            //if(startChecking)
            //{
            //    //if (!Input.GetKeyDown(KeyCode.X)) 
            //    if (Input.GetKey(KeyCode.X))
            //    {
            //        //Debug.Log("Not Holding X [OnTriggerStay]");
            //        FindObjectOfType<ImprovedGrappling>().grappable = true;
            //        FindObjectOfType<ImprovedGrappling>().grapplePoint = GrapplePoint.transform;
            //        //FindObjectOfType<ImprovedGrappling>().grapplePoint = GrapplePoint.transform;
            //    }
            //    else
            //    {
            //        FindObjectOfType<ImprovedGrappling>().grappable = false;
            //        Destroy(other.GetComponent<SpringJoint>());
            //        startChecking = false;
            //    }
            //}
            var grapple = other.GetComponent<ImprovedGrappling>().grappable;

            if(!grapple)
            {
                UIAboveGrapple.SetActive(true);
            }

            if (Input.GetKey(KeyCode.X) && !grapple)
            {
                other.GetComponent<ImprovedGrappling>().grappable = true;
                FindObjectOfType<ImprovedGrappling>().grapplePoint = GrapplePoint.transform;
            }



            //if(Input.GetKeyUp(KeyCode.X))
            //{
            //    FindObjectOfType<ImprovedGrappling>().grappable = false;
            //    Destroy(other.GetComponent<SpringJoint>());
            //}

            //if (Input.GetKeyUp(KeyCode.X))
            //{
            //    //Debug.Log("Not Holding X [OnTriggerStay]");
            //    FindObjectOfType<ImprovedGrappling>().grappable = false;
            //    Destroy(other.GetComponent<SpringJoint>());
            //}

            //assign the grapple Point to the grapple script
            //FindObjectOfType<ImprovedGrappling>().grappable = true;
        }
    }
    // When player leaves the player cannot grapple
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIAboveGrapple.SetActive(false);
        //    FindObjectOfType<ImprovedGrappling>().grappable = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleTrigger : MonoBehaviour
{
    public GameObject Box_A;
    public GameObject Box_B;

    public RumbleDialogue rumbleDialogue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Box_A.SetActive(false);
            Box_B.SetActive(false);
            rumbleDialogue.ShakeCamera(5f, 1f);
        }
    }
}

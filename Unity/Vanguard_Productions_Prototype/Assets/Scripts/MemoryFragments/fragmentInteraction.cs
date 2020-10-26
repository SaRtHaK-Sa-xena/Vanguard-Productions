using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the interaction between player and fragment
/// </summary>
public class fragmentInteraction : MonoBehaviour
{
    public TextMeshProUGUI objText;

    private void Start()
    {
        GameObject fragObjUI = FindObjectOfType<Objectives>().gameObject.transform.GetChild(0).gameObject;
        objText = fragObjUI.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // on collision with player
        if (other.CompareTag("Player"))
        {
            // update objective Manager
            FindObjectOfType<Objectives>().UpdateMemoryFragmentObj(objText);

            // Destroy Particle
            Destroy(this.gameObject);
        }
    }

}

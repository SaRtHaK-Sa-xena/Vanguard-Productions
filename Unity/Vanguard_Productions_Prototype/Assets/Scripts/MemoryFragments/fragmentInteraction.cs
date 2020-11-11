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

    public GameObject memoryDisplay;

    public GameObject memoryManager;

    public Sprite sprite;

    public Sprite[] memoryFragments;

    private void Start()
    {
        GameObject fragObjUI = FindObjectOfType<Objectives>().gameObject.transform.GetChild(0).gameObject;
        objText = fragObjUI.GetComponent<TextMeshProUGUI>();

        // get memory manager
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        // on collision with player
        if (other.CompareTag("Player"))
        {
            memoryManager.GetComponent<memoryManager>().setNextSprite();

            Sprite currentSprite = memoryManager.GetComponent<memoryManager>().currentMemory;

            // Set sprite in Collections
            FindObjectOfType<Objectives>().setSprite(currentSprite);

            // update objective Manager
            FindObjectOfType<Objectives>().UpdateMemoryFragmentObj(objText);

            // display memory
            FindObjectOfType<PauseMenu>().DisplayMemory();

            // Destroy Particle
            Destroy(this.gameObject);
        }
    }

    

}

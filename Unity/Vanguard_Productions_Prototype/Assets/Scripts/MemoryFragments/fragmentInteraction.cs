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

    private void Start()
    {
        GameObject fragObjUI = FindObjectOfType<Objectives>().gameObject.transform.GetChild(0).gameObject;
        objText = fragObjUI.GetComponent<TextMeshProUGUI>();

        // get memory display
        memoryManager = GameObject.FindGameObjectWithTag("memoryManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        // on collision with player
        if (other.CompareTag("Player"))
        {
            // update objective Manager
            FindObjectOfType<Objectives>().UpdateMemoryFragmentObj(objText);

            // set sprite of memory display to fragment sprite
            //memoryDisplay.GetComponent<Image>().sprite = sprite;

            memoryManager.GetComponent<memoryManager>().currentMemory = sprite;

            //memoryDisplay.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprite;

            //FindObjectOfType<PauseMenu>().currentMemorySprite = sprite;

            // display memory
            FindObjectOfType<PauseMenu>().DisplayMemory();


            // Destroy Particle
            Destroy(this.gameObject);
        }
    }

}

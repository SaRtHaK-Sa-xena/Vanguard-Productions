using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryHolder : MonoBehaviour
{
    public GameObject MemoryManager;
    public GameObject pauseMenu;

    private void OnEnable()
    {
        if(MemoryManager.GetComponent<memoryManager>().currentMemory)
        {
            GetComponent<Image>().sprite = MemoryManager.GetComponent<memoryManager>().currentMemory;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            pauseMenu.GetComponent<PauseMenu>().BackToCollections();
        }
    }
}

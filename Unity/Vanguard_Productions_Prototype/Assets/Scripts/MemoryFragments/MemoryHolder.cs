using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryHolder : MonoBehaviour
{
    public GameObject MemoryManager;

    private void OnEnable()
    {
        GetComponent<Image>().sprite = MemoryManager.GetComponent<memoryManager>().currentMemory;
    }
}

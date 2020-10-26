using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles objectives
/// </summary>
public class Objectives : MonoBehaviour
{
    public const float totalFragments = 3;

    // holds memory fragment count
    public float m_Fragment = 0;

    // holds integer for quest number
    public int displayedObj;

    //====Fragment Collection=====
    public GameObject collection1;
    public GameObject collection2;
    public GameObject collection3;

    public Sprite sprite;

    private void Awake()
    {
        displayedObj = 1;
    }

    // Change string based upon collected fragments
    public void UpdateMemoryFragmentObj(TextMeshProUGUI text)
    {
        // increment fragment
        m_Fragment++;

        // Change text upon fragment count
        // create basic string
        string basic = "Collect Memory Fragments (";
        string basic_end = "/ 3)";
        float fragCount = m_Fragment;

        // concatenate into one string
        string result = basic + fragCount.ToString() + basic_end;

        // set resulting string to text
        text.text = result;

        // Update the Objective Count
        UpdateObjectiveCount();

        // Update Collections in Menu
        UpdateCollections();
    }

    private void FixedUpdate()
    {

    }

    public void UpdateCollections()
    {
        if(m_Fragment == 1)
        {
            collection1.GetComponent<Image>().sprite = sprite;
        }
        if(m_Fragment == 2)
        {
            collection2.GetComponent<Image>().sprite = sprite;
        }
        if(m_Fragment == 3)
        {
            collection3.GetComponent<Image>().sprite = sprite;
        }
    }

    public void UpdateObjectiveCount()
    {
        // if all fragments collected
        if(m_Fragment >= totalFragments)
        {
            // increment objective
            IncrementObj();
        }
    }

    public void IncrementObj()
    {
        displayedObj++;
    }
}
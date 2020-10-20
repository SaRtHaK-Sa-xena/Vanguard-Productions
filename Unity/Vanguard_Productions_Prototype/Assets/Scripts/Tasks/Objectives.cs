using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Handles objectives
/// </summary>
public class Objectives : MonoBehaviour
{
    public const float totalFragments = 4;

    // holds memory fragment count
    public float m_Fragment = 0;

    // holds integer for quest number
    public int displayedObj;

    private void Awake()
    {
        displayedObj = 1;
    }

    // Change string based upon collected fragments
    public void UpdateMemoryFragmentObj(Text text)
    {
        // Change text upon fragment count
        // create basic string
        string basic = "Collect Memory Fragments (";
        string basic_end = "/ 4)";
        float fragCount = m_Fragment;

        // concatenate into one string
        string result = basic + fragCount.ToString() + basic_end;

        // set resulting string to text
        text.text = result;

        // Update the Objective Count
        UpdateObjectiveCount();
    }

    private void FixedUpdate()
    {

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
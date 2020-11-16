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
    // total fragments
    public const float totalFragments = 3;

    // holds memory fragment count
    public float m_Fragment = 0;

    // holds integer for quest number
    public int displayedObj;

    // default memory Sprite
    public Sprite defaultMemorySprite;

    //====Fragment Collection=====
    public GameObject collection1;
    public GameObject collection2;
    public GameObject collection3;
    public GameObject collection4;

    // sprite assigned to collection pieces
    public Sprite sprite;

    // memory Manager
    public GameObject memoryManager;

    // task
    public TextMeshProUGUI secondTask; // find postman

    // final task
    public TextMeshProUGUI finalTask; // fight warden

    // final memory position
    public Transform finalMemory;

    // condition to set finaltask to true
    bool finalTaskActivated = false;


    // player Location
    public GameObject Player;

    // postMan variables
    public GameObject postMan;
    public Transform postManPos;
    public GameObject postManDialogue;

    private void Awake()
    {
        displayedObj = 1;
        collection1.GetComponent<Image>().sprite = defaultMemorySprite;
        collection2.GetComponent<Image>().sprite = defaultMemorySprite;
        collection3.GetComponent<Image>().sprite = defaultMemorySprite;
        collection4.GetComponent<Image>().sprite = defaultMemorySprite;
    }

    // Change string based upon collected fragments
    public void UpdateMemoryFragmentObj(TextMeshProUGUI text)
    {
        // increment fragment
        m_Fragment++;

        // Change text upon fragment count
        // create basic string
        string basic = "Collect Memory Fragments - ";
        string basic_end = "/ 3";
        float fragCount = m_Fragment;

        // concatenate into one string
        string result = basic + fragCount.ToString() + basic_end;

        // set resulting string to text
        text.text = result;

        // Update the Objective Count
        UpdateObjectiveCount(text);

        // Update Collections in Menu
        UpdateCollections();
    }

    // Set sprite on collection display upon collection
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
        if(m_Fragment == 4)
        {
            collection4.GetComponent<Image>().sprite = sprite;
        }
    }

    // increment objective if fragments collected greater than total
    public void UpdateObjectiveCount(TextMeshProUGUI text)
    {
        // if all fragments collected
        if (m_Fragment >= totalFragments && !finalTaskActivated)
        {
            // turn on second objective text in UI
            text.gameObject.SetActive(false);
            secondTask.gameObject.SetActive(true);

            // spawn postman
            SpawnPostMan();
        }
        
        if(finalTaskActivated)
        {
            finalTask.gameObject.SetActive(true);
            secondTask.gameObject.SetActive(false);
        }
    }

    public void SpawnPostMan()
    {
        // spawn postman
        postManDialogue.SetActive(true);
        Instantiate(postMan, postManPos);
        postManPos.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    /// turn text of next objective on
    public void FoundPostMan()
    {
        FindObjectOfType<fragSpawner>().SpawnFinalMemory(finalMemory);
    }

    public void DisplayFinalTask()
    {
        finalTaskActivated = true;
        TextMeshProUGUI nullText = new TextMeshProUGUI();
        UpdateObjectiveCount(nullText);
    }

    // set sprite from FragmentInteraction script
    // on collision set sprite to sprite on fragment
    public void setSprite(Sprite a_sprite)
    {
        sprite = a_sprite;
    }

    public void setManagerSprite(Sprite collectionSprite)
    {
        if(memoryManager.GetComponent<memoryManager>().currentMemory)
        {
            memoryManager.GetComponent<memoryManager>().currentMemory = collectionSprite;
        }
    }
}
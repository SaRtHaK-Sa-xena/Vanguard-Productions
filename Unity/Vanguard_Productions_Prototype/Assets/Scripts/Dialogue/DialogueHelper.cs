using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHelper : MonoBehaviour
{
    public GameObject[] dialogueObjs;

    private void Start()
    {
        dialogueObjs = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Finds matching name and removes box collider
    // Receives name in Dialogue Manager
    public void EndDialogueObj(string name)
    {
        // Go through list
        foreach(GameObject obj in dialogueObjs)
        {
           // if name matches item in list
           if(obj.GetComponent<DialogueManager>().nameText.ToString() == name)
           {
                // remove box collider for item in list
                obj.GetComponent<BoxCollider>().enabled = false;
           }
        }
    }


    //send name to this function
    // look for the name and disable box collider of that one
}

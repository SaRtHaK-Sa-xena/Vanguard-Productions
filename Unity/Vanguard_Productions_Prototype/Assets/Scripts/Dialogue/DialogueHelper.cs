using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHelper : MonoBehaviour
{
    // list of all dialogue objs
    public GameObject[] dialogueObjs;

    // Holds display text objs for help
    public TextMeshProUGUI nameDisplay; // manually assigned
    public TextMeshProUGUI sentenceDisplay; // manually assigned



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
           if(obj.GetComponent<DialogueManager>().nameText.text == name)
           {
                Debug.Log("nameText:" + obj.GetComponent<DialogueManager>().nameText.text + " name: " + name);

                Debug.Log("Obj Name: " + obj.name);

                // remove box collider for item in list
                obj.GetComponent<BoxCollider>().enabled = false;
           }
        }
    }


    //send name to this function
    // look for the name and disable box collider of that one
}

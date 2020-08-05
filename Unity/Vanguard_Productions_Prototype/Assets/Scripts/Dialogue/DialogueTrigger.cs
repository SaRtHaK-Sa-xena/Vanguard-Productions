using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        GetComponent<DialogueManager>().StartDialogue(dialogue);
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // on object npc
        if (gameObject.CompareTag("NPC"))
        {
            if(other.CompareTag("Player"))
            {
                // Interacting with Player
                TriggerDialogue();
            }
        }
    }
}

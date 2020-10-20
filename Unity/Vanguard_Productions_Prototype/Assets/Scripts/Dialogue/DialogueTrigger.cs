using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private Transform storedTransform;

    public void TriggerDialogue()
    {
        GetComponent<DialogueManager>().enabled = true;
        GetComponent<DialogueManager>().StartDialogue(dialogue);
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

                other.GetComponent<PlayerControl>().stopMovement();

               // other.GetComponent<Rigidbody>().isKinematic = true;
                Time.timeScale = 0;
                //other.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }
        }
    }
}

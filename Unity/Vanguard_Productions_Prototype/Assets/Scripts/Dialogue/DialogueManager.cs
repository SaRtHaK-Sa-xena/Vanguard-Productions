using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    // assigned in start
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        nameText = FindObjectOfType<DialogueHelper>().nameDisplay;
        dialogueText = FindObjectOfType<DialogueHelper>().sentenceDisplay;
        sentences = new Queue<string>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Debug.Log("sentence count: " + sentences.Count);
            if (sentences.Count != 0)
            {
                DisplayNextSentence();
            }
            else
            {
                //Debug.Log("sentence count: " + sentences.Count);
                EndDialogue();
            }
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        //if(sentences.Count == 0)
        //{
        //    EndDialogue();
        //    return;
        //}

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    
    void EndDialogue()
    {
        FindObjectOfType<DialogueHelper>().EndDialogueObj(nameText.text);
    }
}

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

    public Animator dialogueBoxAnim;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        nameText = FindObjectOfType<DialogueHelper>().nameDisplay;
        dialogueText = FindObjectOfType<DialogueHelper>().sentenceDisplay;
        dialogueBoxAnim = FindObjectOfType<DialogueHelper>().dialogueBoxAnim;
        sentences = new Queue<string>();
        GetComponent<DialogueManager>().enabled = false;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (sentences.Count != 0)
            {
                // set dialogue box animation to true
                dialogueBoxAnim.SetBool("isOpen", true);

                // Display Next Sentence
                DisplayNextSentence();
            }
            else
            {
                EndDialogue();
            }
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        // set dialogue box animation to true
        dialogueBoxAnim.SetBool("isOpen", true);

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
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Type by letter
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    
    void EndDialogue()
    {
        // set dialogue box animation to false
        dialogueBoxAnim.SetBool("isOpen", false);

        // remove collider
        GetComponent<BoxCollider>().enabled = false;

        player.GetComponent<PlayerControl>().startMovement();

        Debug.Log("End Of Dialogue");
    }
}

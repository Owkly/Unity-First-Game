using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    //fonctionne un peu comme une liste, pour imager une file d'attente.
    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de dialogue manager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        // Permet de mettre le nom du pnj à son nom
        nameText.text = dialogue.name;

        // Permet de supprimer les textes affichés sur un moment t
        // Comme ça, si il y a plusieurs pnj, alors on pourra être sur q'un seul message
        // sera affiché
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            //On va donc passer chaque phrase dans la fil d'attente, et le faire dans l'ordre
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // Permet d'arrêter toutes les coroutines, donc l'affichage actuel
        // COmme ça on peut skip rapidement les textes
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Cette fonction permettra d'afficher un par un les lettres du dialogue que l'on veut
    // afficher
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //Permet d'ajouter une lettre et de mettre une frame à chaque interstice
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}

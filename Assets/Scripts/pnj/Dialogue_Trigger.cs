using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange;

    private Text interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUi").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    // Cette fonction permet de lancer les text du pnj
    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}

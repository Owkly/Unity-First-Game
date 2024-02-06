using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;

    private bool isInRange;

    public Animator animator;

    public int coinsToAdd;

    public AudioClip SoundToPlay;

    // Start is called before the first frame update
    void Awake()
    {
        // Permet de récupérer les textes avec le tag interactUI
        interactUI = GameObject.FindGameObjectWithTag("InteractUi").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si la touche E est appuyé, alors on peut ouvrir le coffre
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    // Permet de renseigner à notre animator qu'il faut jouer l'animation
    void OpenChest()
    {
        //Permet d'ajouter une pièce, et de faire un son d'ajout de pièce
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddGems(coinsToAdd);
        AudioManager.instance.PlayClipAt(SoundToPlay, transform.position);

        //Le GetCOmponent permet de récupérer le component du Collider, puis de le
        //désactiver
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false; 
    }

    //Permet de vérifier si le joueur rentre en collision avec le coffre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}

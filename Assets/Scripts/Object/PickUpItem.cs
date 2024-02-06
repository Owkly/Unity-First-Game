using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;

    private bool isInRange;

    public item item;

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
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }

    // Permet de renseigner à notre animator qu'il faut jouer l'animation
    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(SoundToPlay, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);

    }

    //Permet de vérifier si le joueur rentre en collision avec le coffre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

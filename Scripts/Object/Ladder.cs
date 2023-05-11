using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private MovePlayer1 playerMovement;
    public BoxCollider2D topCollider;
    private Text interactUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer1>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUi").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

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
        isInRange = false;
        playerMovement.isClimbing = false;
        topCollider.isTrigger = false;
        interactUI.enabled = false;
    }
}

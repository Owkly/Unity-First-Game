using UnityEngine;
using UnityEngine.UI;

public class Sign_equation : MonoBehaviour
{
    public bool isInRange;

    private Text interactUI;

    public GameObject EquationUI;

    public Animator animator;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUi").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Open();
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
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            Close();
        }
    }

    public void Open()
    {
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        animator.SetBool("isOpen", false);
    }
}

using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Cela permet de déplacer le spawn à chaque fois qu'on traverse un checkpoint
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint= transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

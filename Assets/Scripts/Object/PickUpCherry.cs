using UnityEngine;

public class PickUpCherry : MonoBehaviour
{
    public int CherryHealth = 20;

    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(pickUpSound, transform.position);
            PlayerHealth.instance.GiveHealth(CherryHealth);
            Destroy(gameObject); 
        }
    }
}

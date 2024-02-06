using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip killsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Permet de voir si tout gameobject de tag player entre en collision ou non
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killsound, transform.position);
            //permet de supprimer tous les fichiers ennemi_graphics
            Destroy(objectToDestroy); 
        }
    }
}
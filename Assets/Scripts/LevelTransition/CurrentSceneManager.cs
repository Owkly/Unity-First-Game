using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int GemsPickedUpInThisCount;
    public Vector3 respawnPoint;

    public static CurrentSceneManager instance;
    public int levelToUnlock;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}

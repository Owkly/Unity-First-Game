using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainDoor : MonoBehaviour
{
    public string sceneName;
    private bool isInRange;
    public Animator fadeSystem;
    public Text nextLevel;

    public AudioClip transitionLevel;

    public bool key = false;

    private bool alreadyKey = false;

    public static MainDoor instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }

        instance = this;

        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        nextLevel = GameObject.FindGameObjectWithTag("MainLevel").GetComponent<Text>();
    }

    private void Update()
    {
        if (key == true && alreadyKey == false)
        {
            nextLevel.enabled = false;
            alreadyKey = true;
            nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Text>();
        }
        if (isInRange && Input.GetKeyDown(KeyCode.Y) && key)
        {
            StartCoroutine(loadNextScene());
            nextLevel.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            nextLevel.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        nextLevel.enabled = false;
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        AudioManager.instance.PlayClipAt(transitionLevel, transform.position);
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(sceneName);
    }
}

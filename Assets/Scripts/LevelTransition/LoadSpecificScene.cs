using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private bool isInRange;
    public Animator fadeSystem;
    public Text nextLevel;

    public AudioClip transitionLevel;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Y))
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
        yield return new WaitForSeconds(2.3f) ;
        SceneManager.LoadScene(sceneName);
    }
}

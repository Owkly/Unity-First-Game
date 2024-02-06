using UnityEngine;
using UnityEngine.SceneManagement;

public class credit : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu(); 
        }
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        AudioManager.Instance.Play("Theme");
    }
    public void PlayGame() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

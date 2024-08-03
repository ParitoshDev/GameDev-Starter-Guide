
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private static void SetupInstance()
    {
        instance = FindObjectOfType<UIManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "ScoreManager";
            instance = gameObj.AddComponent<UIManager>();
            DontDestroyOnLoad(gameObj);
        }

    }
    #endregion

    [SerializeField] private GameObject gameOver;
    private void Start()
    {
        gameOver.SetActive(false);
    }
    public void EnableGameOver() { 
        gameOver.SetActive(true);
    }


    public void GoMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;

    }
}

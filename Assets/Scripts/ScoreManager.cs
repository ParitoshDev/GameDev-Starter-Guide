using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region singleton patter
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get {
            if (instance == null) {
                SetupInstance();
            }return instance;
        }
    }

    private static void SetupInstance() { 
        instance = FindObjectOfType<ScoreManager>();
        if (instance == null) {
            GameObject gameObj = new GameObject();
            gameObj.name = "ScoreManager";
            instance = gameObj.AddComponent<ScoreManager>();
            DontDestroyOnLoad(gameObj);
        }

    }

    #endregion+



    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    public int Score
    {
        get { return score; }
    }

   
    public void UpdateScore() {
        try
        {
            score = int.Parse(scoreText.text);
            score++;
            scoreText.SetText(score.ToString());

        }
        catch (InvalidCastException e)
        {
            Debug.LogException(e);
        }

    }
}
